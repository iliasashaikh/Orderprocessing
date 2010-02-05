using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OrderProcessingDomain;
using NHibernate;
using NHibernate.Linq;

namespace OrderProcessing.Tests
{
  [TestFixture]
  public class OrderProcessTest
  {

    [TestFixtureSetUp]
    public void SetupNHProf()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
    }

    [Test]
    public void Test_LoadAllOrders()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
      using (ISession session = NHibernateHelper.OpenSession())
      {
        var orders = session.Linq<Order>();
        Assert.NotNull(orders);
        List<Order> orderList = orders.ToList<Order>();
        Customer c = orderList[0].Customer;
        Employee e = orderList[0].Employee;
        Assert.IsNotEmpty(orders.ToList<Order>());
        Assert.IsNotNull(c);
        Assert.IsNotNull(e);
        Assert.AreEqual("VINET", c.CustomerId);
        Assert.AreEqual(5, e.EmployeeId);
      }
    }

    [Test]
    public void Test_LoadAllOrdersUsingRepository()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

      var orderRepository = new NHRepository<Order>();
      var orders = orderRepository.GetAll();
      List<Order> orderList = orders.ToList<Order>();
      Customer c = orderList[0].Customer;
      Employee e = orderList[0].Employee;
      Assert.IsNotNull(c);
      Assert.IsNotNull(e);
      Assert.AreEqual("VINET", c.CustomerId);
      Assert.AreEqual(5, e.EmployeeId);
    }

    [Test]
    public void Test_LoadCustomerALFKIAndAllOrdersUsingRepository()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

      using (ISession session = NHibernateHelper.OpenSession())
      {
        var customers1 = session.Linq<Customer>().Where(x => x.CustomerId == "ALFKI");

        foreach (Customer c in customers1)
        {
          Customer cc = c;
        }
      }
      var customerRepository = new NHRepository<Customer>();
      var customers = customerRepository.GetByCriteria(x => x.CustomerId == "ALFKI");
      foreach (Customer c in customers)
      {
        Customer cc = c;
      }

    }


    [Test]
    public void Test_LoadAllOrdersFluently()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
      using (ISession session = NHibernateHelper.OpenSessionFluently())
      {
        var orders = session.Linq<Order>();
        Assert.NotNull(orders);
        List<Order> orderList = orders.ToList<Order>();
        Customer c = orderList[0].Customer;
        Employee e = orderList[0].Employee;
        Assert.IsNotEmpty(orders.ToList<Order>());
        Assert.IsNotNull(c);
        Assert.IsNotNull(e);
        Assert.AreEqual("VINET", c.CustomerId);
        Assert.AreEqual(5, e.EmployeeId);
      }
    }

    [Test]
    public void Test_LoadAllOrdersFluentAndHbm()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
      using (ISession session = NHibernateHelper.OpenSessionFluentAndHbm())
      {
        var orders = session.Linq<Order>();
        Assert.NotNull(orders);
        List<Order> orderList = orders.ToList<Order>();
        Assert.IsNotEmpty(orderList);
        Customer c = orderList[0].Customer;
        Employee e = orderList[0].Employee;
        Assert.IsNotNull(c);
        Assert.IsNotNull(e);
        Assert.AreEqual("VINET", c.CustomerId);
        Assert.AreEqual(5, e.EmployeeId);
      }
    }

    [Test]
    public void Test_LoadCustomerALFKIAndAllOrders()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

      using (ISession session = NHibernateHelper.OpenSession())
      {
        var customers = session.Linq<Customer>().Where(x => x.CustomerId == "ALFKI");
        Customer c = customers.ToList<Customer>()[0];
      }
    }

    [Test]
    public void Test_LoadCustomerALFKIAndAllOrdersFluently()
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
      using (ISession session = NHibernateHelper.OpenSessionFluently())
      {
        var customers = session.Linq<Customer>().Where(x => x.CustomerId == "ALFKI").First();
        //Customer c = customers.ToList<Customer>()[0];
        //Assert.AreEqual(6, c.Orders.Count);
      }
    }

    [Test]
    public void Test_LoadEmployee1AndAllOrders()
    {
      using (ISession session = NHibernateHelper.OpenSession())
      {
        var employees = session.Linq<Employee>().Where(x => x.EmployeeId == 1);
        Employee e = employees.ToList<Employee>()[0];
        Assert.AreEqual(123, e.Orders.Count);
      }
    }

    [Test]
    public void Test_LoadEmployee1AndAllOrdersFluently()
    {
      using (ISession session = NHibernateHelper.OpenSessionFluently())
      {
        var employees = session.Linq<Employee>().Where(x => x.EmployeeId == 1);
        Employee e = employees.ToList<Employee>()[0];
        Assert.AreEqual(123, e.Orders.Count);
      }
    }

    [Test]
    public void Test_CanOpenNhibernateSession()
    {
      ISession session = NHibernateHelper.OpenSession();
      session.Close();
    }

    [Test]
    public void Test_SaveOrderAndCommit()
    {
      Order order = new Order();
      order.CustomFields = new System.Collections.Hashtable();
      order.CustomFields.Add("OrderDate", DateTime.Now);
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
      using (ISession session = NHibernateHelper.OpenSession())
      using (ITransaction transaction = session.BeginTransaction())
      {
        var orders = session.Linq<Order>();
        int countBefore = orders.Count();
        session.Save(order);
        transaction.Commit();
        int countAfter = orders.Count();

        Assert.AreEqual(countAfter, countBefore + 1);
      }
    }

    [Test]
    public void Test_SaveOrderAndRollback()
    {
      Order order = new Order();
      order.CustomFields = new System.Collections.Hashtable();
      order.CustomFields.Add("OrderDate", DateTime.Now);
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
      using (ISession session = NHibernateHelper.OpenSession())
      using (ITransaction transaction = session.BeginTransaction())
      {
        var orders = session.Linq<Order>();
        int countBefore = orders.Count();
        session.Save(order);
        transaction.Rollback();
        int countAfter = orders.Count();

        Assert.AreEqual(countAfter, countBefore);
      }
    }

    [Test]
    public void Test_SaveOrderAndCustomerAndEmployeeInATransaction()
    {
    }

    [Test]
    public void Test_DeleteOrder()
    {
    }

    [Test]
    public void Test_UpdateOrder()
    {
    }

    [Test]
    public void Test_DeleteCustomerAndCheckAssociatedOrders()
    {
    }

    [Test]
    public void Test_DeleteEmployeeAndCheckAssociatedOrders()
    {
    }
  }
}
