using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OrderProcessingDomain;
using OrderProcessingDomain.Command;

namespace OrderService
{
  // NOTE: If you change the interface name "ICommandService" here, you must also update the reference to "ICommandService" in App.config.
  [ServiceContract]
  [ServiceKnownType(typeof(AddOrderCommand))]
  [ServiceKnownType(typeof(RemoveOrderCommand))]
  [ServiceKnownType(typeof(UpdateOrderCommand))]
  public interface ICommandService
  {
    [OperationContract]
    ICommand ExecuteCommand(ICommand command);

    [OperationContract]
    ICommand Undo();
  }
}
