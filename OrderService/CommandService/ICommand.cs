﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderService
{
  public interface ICommand
  {
    void Execute();
    void Undo();
    void Redo();
  }
}
