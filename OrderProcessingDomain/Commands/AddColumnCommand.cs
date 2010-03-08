using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using OrderProcessingDomain.Repositories;

namespace OrderProcessingDomain.Command
{

  public class AddColumnCommand : ICommand
  {
    #region ICommand Members

    string _columnName;
    CustomColumnType _columnType;
    Type _entityType;

    public AddColumnCommand(Type entityType, string columnName, CustomColumnType columnType)
    {
      _entityType = entityType;
      _columnName = columnName;
      _columnType = columnType;
    }
    
    public AddColumnCommand(string columnName, CustomColumnType columnType)
    {
      _columnName = columnName;
      _columnType = columnType;
    }

    public void Execute()
    {
      IOC.RegisterComponents();
      Type repository_T = Repositiory.GetGenericType(_entityType);
      MethodInfo mi = repository_T.GetMethod("AddCustomColumn", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      mi.Invoke(null, new object[] { _columnName, _columnType, Common.Util.GetContextId() });
    }

    public void Undo()
    {
      throw new InvalidOperationException("Cannot undo the addition of a custom column automatically");
    }

    public void Redo()
    {
      throw new NotSupportedException("This operation is not supported");
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
