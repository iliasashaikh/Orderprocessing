using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderService.CommandService
{
  class CommandController
  {
    static Dictionary<int, Stack<ICommand>> _commands = new Dictionary<int, Stack<ICommand>>();


  }
}
