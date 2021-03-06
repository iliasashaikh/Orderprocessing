﻿using System;
using System.Diagnostics;
using System.Linq;

using Castle.MicroKernel.Registration;
using Castle.Windsor;

using NUnit.Framework;

using OrderProcessingDomain;

using Spring.Context;
using Spring.Context.Support;

namespace OrderProcessing.Tests
{
  [TestFixture]
  [Ignore]
  public class OrderProcessTestForIOC
  {
		#region Static fields (4)
		const string DAC_MANAGER = "dacmanager";
		const string NHDAC = "nhdac";
		const string OBJECT_DAC = "objectdac";
		const string REPOSITORY_FACTORY = "repfactory";
		#endregion

		#region Methods (6)
		[Test]
    [Ignore]
    public void SetupContainerUsingSpring()
    {
      try
      {
        IApplicationContext context = ContextRegistry.GetContext();
        var dao = context.GetObjectsOfType(typeof(NHDataAccessContext));
        var daoNH = context.GetObject("nhDataAccessContext");
        var daoNH1 = context.GetObject("nhDataAccessContext");
        var dacManager = context.GetObject("dacManager");
        var dacManager1 = context.GetObject("dacManager");
        Assert.That(dao, Is.Not.Null);
        Assert.That(dacManager, Is.EqualTo(dacManager1));
        Assert.That(daoNH, Is.Not.EqualTo(daoNH1));
      }
      catch (Exception ex)
      {
        ShowError(ex);
        throw;
      }
    }

		[Test]
    [Ignore]
    public void SetupContainerUsingWindsor()
    {
      IWindsorContainer _container = new WindsorContainer();

      _container.Register(
      Component.For<DACManager>().Named(DAC_MANAGER).LifeStyle.Singleton,
      Component.For<IDataAccessContext>().ImplementedBy<NHDataAccessContext>().Named(NHDAC).LifeStyle.Transient,
      Component.For<IDataAccessContext>().ImplementedBy<ObjectDataAccessContext>().Named(OBJECT_DAC).LifeStyle.Transient,
      Component.For(typeof(IRepository<>)).ImplementedBy(typeof(NHRepository<>)).ServiceOverrides(ServiceOverride.ForKey("dac").Eq(NHDAC)).LifeStyle.Transient.Named("nhrep1"),
      Component.For(typeof(IRepository<>)).ImplementedBy(typeof(NHRepository<>)).LifeStyle.Transient.Named("nhrep").LifeStyle.Transient,
      Component.For(typeof(IRepository<>)).ImplementedBy(typeof(ObjectRepository<>)).LifeStyle.Transient,
      Component.For(typeof(Repository<>)).Named(REPOSITORY_FACTORY).LifeStyle.Singleton
      );

      var nhdac = _container.Resolve<IDataAccessContext>(NHDAC);
      Assert.That(nhdac, Is.InstanceOf<NHDataAccessContext>());
      var objdac = _container.Resolve<IDataAccessContext>(OBJECT_DAC);
      Assert.That(objdac, Is.InstanceOf<ObjectDataAccessContext>());
      var objNHRepo = _container.Resolve<IRepository<Order>>("nhrep");
      var objNHRepo1 = _container.Resolve<IRepository<Order>>("nhrep1");
    }

		void ShowError(Exception ex)
    {
      Debug.WriteLine(ex.Message);
      Debug.WriteLine(ex.StackTrace);
      if (ex.InnerException != null)
      {
        Debug.WriteLine("---------------------");
        ShowError(ex.InnerException);
      }
    }

		[Test]
    public void Test_AddOrderDetails()
    {
      IOC.RegisterComponents();
      Order order = Repository<Order>.All(this).First();
      Product product = Repository<Product>.All(this).First();
      OrderDetail ordDetail = new OrderDetail() { Discount = 0, Quantity = 1, ParentOrder = order, ParentProduct = product };
      Repository<OrderDetail>.Save(ordDetail, this);
    }

		/// <summary>
    /// Test_s the add order in A transaction using DAC.
    /// </summary>
    [Test]
    public void Test_AddOrderInATransactionUsingDAC()
    {
      IOC.RegisterComponents();
      var orders = Repository<Order>.All(this);
      int countBefore = orders.Count();
      DACManager.BeginTransaction(this);
      Repository<Order>.Save(new Order() { }, this);
      DACManager.Commit(this);
      Assert.That(countBefore + 1, Is.EqualTo(orders.Count()));
    }

		[Test]
    public void Test_GetAllOrdersUsingDAC()
    {
      IOC.RegisterComponents();
      var orders = Repository<Order>.All(this);
      Assert.Greater(orders.Count(), 0);
      //DACManager.CloseSession(this);
    }

    [Test]
    public void Test_GetCustomerALFKI()
    {
      IOC.RegisterComponents();
      var orders = Repository<Customer>.Where(x=>x.CustomerId == "ALFKI",this);
      Assert.Greater(orders.Count(), 0);
    }

    [Test]
    public void Test_GetOrdersUsingDAC()
    {
      IOC.RegisterComponents();
      var orders = Repository<Order>.All(this);
      Assert.Greater(orders.Count(), 0);
      //DACManager.CloseSession(this);
    }
		#endregion
  }
}
