using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using OrderProcessingDomain.Command;

namespace OrderService
{
  // NOTE: If you change the class name "CommandService" here, you must also update the reference to "CommandService" in App.config.
  public class CommandService : ICommandService
  {
    #region ICommandService Members

    static Dictionary<string, Stack<ICommand>> _clientCommands = new Dictionary<string,Stack<ICommand>>();

    public ICommand ExecuteCommand(ICommand command)
    {
      Stack<ICommand> commandStack = GetCommandStack();
      command.Execute();
      commandStack.Push(command);
      return command;
    }

    public ICommand Undo()
    {
      Stack<ICommand> commandStack = GetCommandStack();
      if (commandStack.Count > 0)
      {
        ICommand command = commandStack.Pop();
        command.Undo();
        return command;
      }
      return null;
    }

    Stack<ICommand> GetCommandStack()
    {
      string sessionId = GetContextId();

      if (!_clientCommands.Keys.Contains(sessionId))
        _clientCommands.Add(sessionId, new Stack<ICommand>());

      Stack<ICommand> commandStack = _clientCommands[sessionId];

      return commandStack;
    }

    string GetContextId()
    {
      if (OperationContext.Current == null)
        return Thread.CurrentContext.ContextID.ToString();
      else
        return OperationContext.Current.SessionId;
    }


    #endregion
  }
}
