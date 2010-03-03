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
  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,InstanceContextMode=InstanceContextMode.PerCall)]
  public class OrderService : IOrders
  {
    static List<IOrderServiceCallback> _subscriberList = new List<IOrderServiceCallback>();
  
    public void AddOrder(Order order)
    {
      Repository<Order>.Save(order, Common.Util.GetContextId());
      new Thread(()=> NotifySubscribers("Add", order)).Start();
    }

    public void DeleteOrder(Order order)
    {
      try
      {
        IOC.RegisterComponents();
        Order localOrder = Repository<Order>.Get(order.OrderId, Common.Util.GetContextId());
        if (localOrder == null)
        {
          localOrder = Repository<Order>.Where(x => x.OrderId == order.OrderId,Common.Util.GetContextId()).FirstOrDefault();
        }

        if (localOrder != null)
        {
          var orderDetails = Repository<OrderDetail>.Where(x => x.ParentOrder.OrderId == order.OrderId, Common.Util.GetContextId());
          foreach (OrderDetail det in orderDetails)
          {
            Repository<OrderDetail>.Remove(det, Common.Util.GetContextId());
          }
        }

        Repository<Order>.Remove(localOrder, Common.Util.GetContextId());

        new Thread(()=> NotifySubscribers("Delete", order)).Start();
      }
      catch (Exception ex)
      {
        throw new FaultException(ex.Message);
      }
    }


    int xx = 10;

    public IEnumerable<Order> GetAllOrders()
    {
      try
      {
        xx++;

        IOC.RegisterComponents();
        return Repository<Order>.All(Common.Util.GetContextId());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }

      return null;
    }

    public long GetOrderCount()
    {
      IOC.RegisterComponents();
      return Repository<Order>.Count(Common.Util.GetContextId());
    }

    #region IOrders Members


    public void UpdateOrder(Order order)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IOrders Members


    public void Subscribe()
    {
      IOrderServiceCallback callback = OperationContext.Current.GetCallbackChannel<IOrderServiceCallback>();
      _subscriberList.Add(callback);
    }

    public void UnSubscribe()
    {
      IOrderServiceCallback callback = OperationContext.Current.GetCallbackChannel<IOrderServiceCallback>();
      _subscriberList.Remove(callback);
    }

    void NotifySubscribers(string action, Order order)
    {
      if (action == "Add")
      {
        foreach (IOrderServiceCallback client in _subscriberList)
        {
          new Thread(() =>
          {
            try
            {
              client.OrderAdded(order);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
          }).Start();
        }
      }

      if (action == "Delete")
      {
        foreach (IOrderServiceCallback client in _subscriberList)
        {
          try
          {
            client.OrderRemoved(order);
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          //new Thread(() =>
          //{
          //  try
          //  {
          //    client.OrderRemoved(order);
          //  }
          //  catch (Exception ex)
          //  {
          //    Console.WriteLine(ex.Message);
          //  }
          //}).Start();
        }
      }
    }

    #endregion

    #region IOrders Members


    public IEnumerable<Customer> GetAllCustomers()
    {
      IOC.RegisterComponents();
      return Repository<Customer>.All(Common.Util.GetContextId());
    }

    #endregion
  }
}