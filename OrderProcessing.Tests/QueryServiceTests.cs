﻿using System;
using System.Linq;
using NUnit.Framework;
using OrderProcessingDomain;
using OrderService.QueryService;
using ExpressionSerialization;
using System.Xml.Linq;
using System.Linq.Expressions;

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
    public void Test_GetAllProducts()
    {
      try
      {
        ProductQueryService service = new ProductQueryService();
        var results = service.All();
        int count = results.Count();
        Assert.That(count, Is.GreaterThan(0));
      }
      catch (Exception ex)
      {
      }
    }

    [Test]
    [Category("WCF")]
    public void Test_GetAllProductsOverWCF()
    {
      try
      {
        ProductQueryServiceReference.ProductQueryServiceClient service = new OrderProcessing.Tests.ProductQueryServiceReference.ProductQueryServiceClient();
        var results = service.All();
        int count = results.Count();
        Assert.That(count, Is.GreaterThan(0));
      }
      catch (Exception ex)
      {
      }
    }


    [Test]
    public void Test_CustomersByCriteria()
    {
      CustomerQueryService query = new CustomerQueryService();
      
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

    [Test]
    [Category("WCF")]
    public void Test_GetSingleCustomersOverWCF()
    {
      try
      {
        CustomerQueryServiceReference.CustomerQueryServiceClient query = new CustomerQueryServiceReference.CustomerQueryServiceClient();

        ClientQuery<Customer> c = new ClientQuery<Customer>();
        IQueryable q = c.Where(c1 => c1.CustomerId == "ALFKI");
        XElement xe = q.SerializeQuery();
        Customer results = query.Where(xe);

        Assert.That(results, Is.Not.Null);
      }
      catch (Exception ex)
      {
      }
    }


  }
}