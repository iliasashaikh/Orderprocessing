using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;

using System.Threading;
using System.Collections;

namespace OrderProcessingDomain
{
  public class ObjectDataAccessContext : IDataAccessContext
  {
    #region IDataAccessContext Members
    IList _list;

    public void SetupData(IList list)
    {
      _list = list;
    }

    public void OpenSession()
    {
      return;
    }

    public void Save(object toSave)
    {
      return;
    }

    public void Commit()
    {
      return;
    }

    public void Rollback()
    {
      return;
    }

    #endregion

    #region IDataAccessContext Members


    public void Save()
    {
    }

    #endregion

    #region IDataAccessContext Members


    public void BeginTransaction()
    {
      throw new NotImplementedException();
    }

    public void CancelQuery()
    {
      return;
    }

    public void CloseSession()
    {
      return;
    }

    #endregion

    #region IDataAccessContext Members


    public string GetTableName(Type t)
    {
      throw new NotImplementedException();
    }

    #endregion
  }

}
