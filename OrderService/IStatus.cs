using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OrderProcessingDomain;

namespace OrderService
{
  // NOTE: If you change the interface name "IStatus" here, you must also update the reference to "IStatus" in App.config.
  [ServiceContract]
  public interface IStatus
  {
    [OperationContract]
    IEnumerable<Order> GetAllOrders();
  }
}
