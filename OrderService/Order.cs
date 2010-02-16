using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using OrderProcessingDomain;

using System.Threading;
using System.Diagnostics;

namespace OrderService
{
  // NOTE: If you change the class name "Order" here, you must also update the reference to "Order" in App.config.
  public class Orders : IOrders
  {
    public void AddOrder(Order order)
    {
      Repository<Order>.Save(order, Thread.CurrentContext.ContextID);
    }

    public void DeleteOrder(Order order)
    {
      //Order localOrder = Repository<Order>.Where(o => (o.OrderId == order.OrderId),Thread.CurrentContext.ContextID).First();
      Order localOrder = Repository<Order>.Get(order.OrderId, Thread.CurrentContext.ContextID);
      Repository<Order>.Remove(localOrder, Thread.CurrentContext.ContextID);
    }

    public IEnumerable<Order> GetAllOrders()
    {
      try
      {
        IOC.RegisterComponents();
        return Repository<Order>.All(Thread.CurrentContext.ContextID);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }

      return null;
    }

    public int GetOrderCount()
    {
      return Repository<Order>.Count(Thread.CurrentContext.ContextID);
    }
  }
}