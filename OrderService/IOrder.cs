using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Threading;

using OrderProcessingDomain;

namespace OrderService
{
  // NOTE: If you change the interface name "IOrder" here, you must also update the reference to "IOrder" in App.config.
  [ServiceContract]
  public interface IOrders
  {
    [OperationContract]
    void AddOrder(Order order);

    [OperationContract]
    void DeleteOrder(Order order);

    [OperationContract]
    IEnumerable<Order> GetAllOrders();

    [OperationContract]
    int GetOrderCount();
  }
}
