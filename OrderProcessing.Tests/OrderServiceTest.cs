using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderService;
using OrderProcessingDomain;

using NUnit.Framework;

using ExpressionSerialization;

namespace OrderProcessing.Tests
{
  [TestFixture]
  [Ignore]
  public class OrderServiceTest
  {
    [Test]
    public void Test_LoadAllOrders()
    {
      OrderService.OrderService ordService = new OrderService.OrderService();
      var orders = ordService.GetAllOrders();
      Assert.That(orders.Count(), Is.GreaterThan(0));
    }

    [Test]
    public void Test_DeleteOrderAndOrderDetailsCascaded()
    {
      OrderService.OrderService ordService = new OrderService.OrderService();
      Order o = new Order() { OrderId=10263};
      ordService.DeleteOrder(o);
    }

    public void Test_QuerySerialization()
    {
      CustomerQueryServiceReference.CustomerQueryServiceClient client = new OrderProcessing.Tests.CustomerQueryServiceReference.CustomerQueryServiceClient();
    }

  }
}
