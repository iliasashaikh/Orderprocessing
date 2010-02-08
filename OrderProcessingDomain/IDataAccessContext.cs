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
  public interface IDataAccessContext
  {
    void OpenSession();
    void BeginTransaction();
    void Save(object toSave);
    void Commit();
    void Rollback();
  }

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

    #endregion
  }

  public class NHDataAccessContext : IDataAccessContext
  {
    private static ISessionFactory _sessionFactory;

    private ISession _session;

    public ISession Session
    {
      get { return _session; }
      set { _session = value; }
    }

    private ITransaction _transaction;

    public void OpenSession()
    {
      if (_session != null && _session.Connection.State == System.Data.ConnectionState.Open)
        return;

      if (_sessionFactory != null)
      {
        _session = _sessionFactory.OpenSession();
        return;
      }

      Configuration cfg = new Configuration().Configure();
      FluentConfiguration fluentCfg = Fluently.Configure(cfg);
      fluentCfg.Mappings(m=>m.FluentMappings.AddFromAssemblyOf<OrderMap>());
      _sessionFactory = fluentCfg.BuildSessionFactory();
      _session = _sessionFactory.OpenSession();
    }

    public void Save(object toSave)
    {
      _session.Save(toSave);
    }

    public void BeginTransaction()
    {
      if (_transaction != null)
        return;

      OpenSession();

      _transaction = _session.BeginTransaction();

    }

    public void Commit()
    {
      _transaction.Commit();  
    }

    public void Rollback()
    {
      _transaction.Rollback();
    }
  }
}
