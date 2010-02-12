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
      Repository<Order>.Remove(order, Thread.CurrentContext.ContextID);
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
        Debug.WriteLine(ex.Message);
        Debug.WriteLine(ex.StackTrace);
      }

      return null;
    }

    public int GetOrderCount()
    {
      return Repository<Order>.Count(Thread.CurrentContext.ContextID);
    }
  }
}