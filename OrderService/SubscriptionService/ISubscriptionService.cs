using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace OrderService.SubscriptionService
{
  [ServiceContract(CallbackContract=typeof(INotification))]
  interface ISubscriptionService
  {
    [OperationContract]
    void Subscribe();
    [OperationContract]
    void UnSubscribe();
  }

  interface INotification
  {
    [OperationContract(IsOneWay=true)]
    void Notify(string message);
  }
}
