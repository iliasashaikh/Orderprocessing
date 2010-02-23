using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OrderProcessingDomain;

namespace OrderService
{
  // NOTE: If you change the interface name "ICommandService" here, you must also update the reference to "ICommandService" in App.config.
  [ServiceContract]
  public interface ICommandService
  {
    void ExecuteCommand(ICommand command);
    void Undo();
  }
}
