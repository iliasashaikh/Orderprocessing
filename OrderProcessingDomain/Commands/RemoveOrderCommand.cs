using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;

namespace OrderProcessingDomain.Command
{
  public class RemoveOrderCommand : ICommand
  {
    Order _order;
    List<OrderDetails> _orderDetailsList;

    public RemoveOrderCommand(Order order)
    {
      _order = order;
    }

    #region ICommand Members

    public void Execute()
    {
      IOC.RegisterComponents();
      Order localOrder = Repository<Order>.Get(_order.OrderId, Thread.CurrentContext.ContextID);
      
      if (localOrder == null)
      {
        localOrder = Repository<Order>.Where(x => x.OrderId == _order.OrderId, Thread.CurrentContext.ContextID).FirstOrDefault();
      }

      if (localOrder != null)
      {
        var _orderDetails = Repository<OrderDetails>.Where(x => x.OrderId == _order.OrderId, Thread.CurrentContext.ContextID);
        _orderDetailsList = _orderDetails.ToList();
        foreach (OrderDetails det in _orderDetails)
        {
          Repository<OrderDetails>.Remove(det, Thread.CurrentContext.ContextID);
        }
      }
      Repository<Order>.Remove(localOrder, Thread.CurrentContext.ContextID);
    }

    public void Undo()
    {
      Repository<Order>.Save(_order, Thread.CurrentContext.ContextID);
      foreach (OrderDetails det in _orderDetailsList)
      {
        det.OrderId = _order.OrderId.Value;
        Repository<OrderDetails>.Save(det, Thread.CurrentContext.ContextID);
      }

    }

    public void Redo()
    {
      throw new NotImplementedException();
    }

    public List<object> CommandParams
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }
    #endregion
  }
}
