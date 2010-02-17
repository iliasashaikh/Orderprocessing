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
      try
      {
        IOC.RegisterComponents();
        Order localOrder = Repository<Order>.Get(order.OrderId, Thread.CurrentContext.ContextID);
        if (localOrder == null)
        {
          localOrder = Repository<Order>.Where(x => x.OrderId == order.OrderId,Thread.CurrentContext.ContextID).FirstOrDefault();
        }

        if (localOrder != null)
        {
          var orderDetails = Repository<OrderDetails>.Where(x => x.OrderId == order.OrderId, Thread.CurrentContext.ContextID);
          foreach (OrderDetails det in orderDetails)
          {
            Repository<OrderDetails>.Remove(det, Thread.CurrentContext.ContextID);
          }
        }

        Repository<Order>.Remove(localOrder, Thread.CurrentContext.ContextID);

      }
      catch (Exception ex)
      {
        throw new FaultException(ex.Message);
      }
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