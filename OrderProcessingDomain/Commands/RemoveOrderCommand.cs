using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;

using System.ServiceModel;
using System.Runtime.Serialization;

using OrderProcessingDomain;

namespace OrderProcessingDomain.Command
{
  [DataContract]
  public class RemoveOrderCommand : ICommand
  {
    [DataMember]
    Order _order;
    List<OrderDetail> _orderDetailsList;

    public RemoveOrderCommand(Order order)
    {
      _order = order;
    }

    #region ICommand Members

    public void Execute()
    {
      IOC.RegisterComponents();
      Order localOrder = Repository<Order>.Get(_order.OrderId, Utils.GetContextId());
      
      if (localOrder == null)
      {
        localOrder = Repository<Order>.Where(x => x.OrderId == _order.OrderId, Utils.GetContextId()).FirstOrDefault();
      }

      if (localOrder != null)
      {
        var _orderDetails = Repository<OrderDetail>.Where(x => x.ParentOrder.OrderId == _order.OrderId, Utils.GetContextId());
        _orderDetailsList = _orderDetails.ToList();
        foreach (OrderDetail det in _orderDetails)
        {
          Repository<OrderDetail>.Remove(det, Utils.GetContextId());
        }
      }
      Repository<Order>.Remove(localOrder, Utils.GetContextId());
    }

    public void Undo()
    {
      
      Customer persistentCustomer = null;
      Employee persistentEmployee = null;

      if (_order.Customer != null)
        persistentCustomer = Repository<Customer>.Get(_order.Customer.CustomerId, Utils.GetContextId());

      if (_order.Employee != null)
        persistentEmployee = Repository<Employee>.Get(_order.Employee.EmployeeId, Utils.GetContextId());

      _order.Employee = persistentEmployee;
      _order.Customer = persistentCustomer;

      Repository<Order>.Save(_order, Utils.GetContextId());
      foreach (OrderDetail det in _orderDetailsList)
      {
        det.ParentOrder = _order;
        Repository<OrderDetail>.Save(det, Utils.GetContextId());
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
        return new List<object>() { _order };
      }
      set
      {
        _order = value[0] as Order;
      }
    }
    #endregion

    public override string ToString()
    {
      return String.Format("Remove Order - {0}",_order.OrderId.Value.ToString());
    }

    public override bool Equals(object obj)
    {
      RemoveOrderCommand cmd  = obj as RemoveOrderCommand;
      if (cmd != null)
      {
        return (cmd._order.OrderId == this._order.OrderId);
      }

      return false;
    }

  }
}
