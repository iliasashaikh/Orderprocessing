using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using OrderProcessingDomain.Command;

using OrderService.SubscriptionService;

namespace OrderService
{
  [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Single)]
  public class CommandService : ICommandService
  {
    #region ICommandService Members

    static Dictionary<string, Stack<ICommand>> _clientCommands = new Dictionary<string,Stack<ICommand>>();

    public ICommand ExecuteCommand(ICommand command)
    {
      Stack<ICommand> commandStack = GetCommandStack();
      command.Execute();
      SubscriptionService.SubscriptionService.NotifyAll(command.ToString());
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
        SubscriptionService.SubscriptionService.NotifyAll(String.Format("Reverted - {0}", command.ToString()));
        return command;
      }
      return null;
    }

    public ICommand UndoCommand(ICommand command)
    {
      Stack<ICommand> commandStack = GetCommandStack();
      if (commandStack.Count > 0 && commandStack.Contains(command))
      {
        ICommand localCommand = commandStack.Where(x => x.Equals(command)).First();
        localCommand.Undo();
        return localCommand;
      }
      return null;
    }

    Stack<ICommand> GetCommandStack()
    {
      string sessionId = Common.Util.GetContextId();

      if (!_clientCommands.Keys.Contains(sessionId))
        _clientCommands.Add(sessionId, new Stack<ICommand>());

      Stack<ICommand> commandStack = _clientCommands[sessionId];

      return commandStack;
    }

   


    #endregion
  }
}
