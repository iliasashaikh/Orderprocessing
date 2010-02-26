﻿using System.Linq;
using NUnit.Framework;
using OrderProcessingDomain;
using OrderService.QueryService;

namespace OrderProcessing.Tests
{
  [TestFixture]
  public class QueryServiceTests
  {
    [Test]
    public void Test_GetAllEmployees()
    {
      CustomerQueryService query = new CustomerQueryService();
      var results = query.All();
      int count = results.Count();
      Assert.That(count, Is.GreaterThan(0));
    }

    [Test]
    public void Test_GetAllOrders()
    {
      OrderQueryService query = new OrderQueryService();
      var results = query.All();
      int count = results.Count();
      Assert.That(count, Is.GreaterThan(0));
    }

    [Test]
    public void Test_GetAllCustomers()
    {
      CustomerQueryService query = new CustomerQueryService();
      var results = query.All();
      int count = results.Count();
      Assert.That(count, Is.GreaterThan(0));
    }

    [Test]
    [Category("WCF")]
    public void Test_GetAllEmployeesOverWCF()
    {
      EmployeeQueryServiceReference.EmployeeQueryServiceClient query = new OrderProcessing.Tests.EmployeeQueryServiceReference.EmployeeQueryServiceClient();
      Employee[] results = query.All();
      int count = results.Length;
      Assert.That(count, Is.GreaterThan(0));
    }

    [Test]
    [Category("WCF")]
    public void Test_GetAllOrdersOverWCF()
    {
      OrderQueryServiceReference.OrderQueryServiceClient query = new OrderProcessing.Tests.OrderQueryServiceReference.OrderQueryServiceClient();
      Order[] results = query.All();
      int count = results.Length;
      Assert.That(count, Is.GreaterThan(0));
    }

    [Test]
    [Category("WCF")]
    public void Test_GetAllCustomersOverWCF()
    {
      CustomerQueryServiceReference.CustomerQueryServiceClient query = new CustomerQueryServiceReference.CustomerQueryServiceClient();
      Customer[] results = query.All();
      int count = results.Length;
      Assert.That(count, Is.GreaterThan(0));
    }



  }
}
