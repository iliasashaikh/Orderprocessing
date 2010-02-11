using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using NUnit.Framework;

using Spring.Core;
using Spring.Context;
using Spring.Context.Support;

using OrderProcessingDomain;
using System.Diagnostics;

using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;


namespace OrderProcessing.Tests
{
  [TestFixture]
  class OrderProcessTestForIOC
  {
    [Test]
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
    public void SetupContainerUsingWindsor()
    {
      try
      {
        IWindsorContainer container = new WindsorContainer();

        container.Register(
          Component.For<IDataAccessContext>().ImplementedBy<NHDataAccessContext>().Named("NHDAC").LifeStyle.Transient,
          Component.For<IDataAccessContext>().ImplementedBy<ObjectDataAccessContext>().Named("ObjectDAC").LifeStyle.Transient
          );

        var nhdac = container.Resolve<IDataAccessContext>("NHDAC");
        Assert.That(nhdac, Is.InstanceOf<NHDataAccessContext>());

        var objdac = container.Resolve<IDataAccessContext>("NHDAC");
        Assert.That(objdac, Is.InstanceOf<ObjectDataAccessContext>());
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }

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

  }
}
