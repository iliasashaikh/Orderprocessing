using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessingDomain.Command
{
  public interface ICommand
  {
    void Execute();
    void Undo();
    void Redo();

    List<object> CommandParams { get; set; }
  }
}
