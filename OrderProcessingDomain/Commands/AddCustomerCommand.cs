﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderProcessingDomain;

using System.Threading;
using System.Runtime.Serialization;

namespace OrderProcessingDomain.Command
{
  [DataContract]
  public class AddOrderCommand : ICommand
  {
    [DataMember]
    Order _order;

    public AddOrderCommand(Order order)
    {
      _order = order;
    }
    #region ICommand Members

    public void Execute()
    {
      IOC.RegisterComponents();
      Repository<Order>.Save(_order, Thread.CurrentContext.ContextID);
    }

    public void Undo()
    {
      Order localOrder = Repository<Order>.Get(_order.OrderId, Thread.CurrentContext.ContextID);
      if (localOrder == null)
      {
        localOrder = Repository<Order>.Where(x => x.OrderId == _order.OrderId, Thread.CurrentContext.ContextID).FirstOrDefault();
      }

      if (localOrder != null)
      {
        var orderDetails = Repository<OrderDetails>.Where(x => x.OrderId == _order.OrderId, Thread.CurrentContext.ContextID);
        foreach (OrderDetails det in orderDetails)
        {
          Repository<OrderDetails>.Remove(det, Thread.CurrentContext.ContextID);
        }
      }

      Repository<Order>.Remove(localOrder, Thread.CurrentContext.ContextID);
    }

    public void Redo()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region ICommand Members


    public List<object> CommandParams
    {
      get
      {
        return new List<object>() { _order };
      }
      set
      {
        _order = value[0] as Order;
      }
    }

    #endregion
  }
}
