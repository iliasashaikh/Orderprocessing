using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessingDomain.Command
{
  public class UpdateOrderCommand : ICommand
  {
    Order _order;

    #region ICommand Members

    public void Execute()
    {
      IOC.RegisterComponents();

    }

    public void Undo()
    {
      throw new NotImplementedException();
    }

    public void Redo()
    {
      throw new NotImplementedException();
    }

    public List<object> CommandParams
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    #endregion
  }
}
