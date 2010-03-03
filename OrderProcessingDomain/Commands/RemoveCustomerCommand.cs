using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderProcessingDomain;
using System.Runtime.Serialization;

namespace OrderProcessingDomain.Command
{
  [DataContract]
  public class RemoveCustomerCommand : ICommand
  {
    #region ICommand Members

    [DataMember]
    Customer _customer;

    public RemoveCustomerCommand(Customer customer)
    {
      _customer = customer;
    }

    public void Execute()
    {
      IOC.RegisterComponents();
      Customer localCustomer = Repository<Customer>.Get(_customer.CustomerId ,Common.Util.GetContextId());
      Repository<Customer>.Remove(localCustomer, Common.Util.GetContextId());
    }

    public void Undo()
    {
      IOC.RegisterComponents();
      var localOrders = _customer.Orders;
      _customer.Orders = null;
      Repository<Customer>.Save(_customer, Common.Util.GetContextId());
    }

    public void Redo()
    {
      throw new NotImplementedException();
    }

    public List<object> CommandParams
    {
      get
      {
        return new List<object>() { _customer };
      }
      set
      {
        _customer = value[0] as Customer;
      }
    }

    public override string ToString()
    {
      return String.Format("Remove Customer - {0}", _customer.CustomerId);
    }

    #endregion
  }
}
