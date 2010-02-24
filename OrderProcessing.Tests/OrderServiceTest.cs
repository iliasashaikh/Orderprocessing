using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderService;
using OrderProcessingDomain;

using NUnit.Framework;

namespace OrderProcessing.Tests
{
  [TestFixture]
  public class OrderServiceTest
  {
    [Test]
    public void Test_LoadAllOrders()
    {
      OrderService.OrderService ordService = new OrderService.OrderService();
      var orders = ordService.GetAllOrders();
      Assert.That(orders.Count(), Is.GreaterThan(0));
    }

    public void Test_DeleteOrderAndOrderDetailsCascaded()
    {
      OrderService.OrderService ordService = new OrderService.OrderService();
      Order o = new Order() { OrderId=10263};
      ordService.DeleteOrder(o);
    }
  }
}
