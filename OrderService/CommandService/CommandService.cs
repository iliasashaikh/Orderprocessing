using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OrderService.CommandService
{
  // NOTE: If you change the class name "CommandService" here, you must also update the reference to "CommandService" in App.config.
  public class CommandService : ICommandService
  {
    #region ICommandService Members

    public void ExecuteCommand(ICommand command)
    {
      
    }

    public void Undo()
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
