﻿using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace OrderProcessingDomain
{
  public class NHDataAccessContext : IDataAccessContext
  {
    private static ISessionFactory _sessionFactory;
    private static Configuration _cfg;
    private ISession _session;

    public NHDataAccessContext()
    {
      if (_cfg == null)
        _cfg = new Configuration().Configure();

      FluentConfiguration fluentCfg = Fluently.Configure(_cfg);
      fluentCfg.Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>().ExportTo(@"c:\temp"));
      _sessionFactory = fluentCfg.BuildSessionFactory();
      ValidatorEngine engine = new ValidatorEngine();
      engine.Configure();

      ValidatorInitializer.Initialize(_cfg, engine);
    }

    public ISession Session
    {
      get { return _session; }
      set { _session = value; }
    }

    public void OpenSession()
    {
      if (_session != null && _session.IsConnected == true)
        return;

      if (_sessionFactory != null)
      {
        _session = _sessionFactory.OpenSession();
        return;
      }

      //FluentConfiguration fluentCfg = Fluently.Configure(_cfg);
      //fluentCfg.Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>());
      //_sessionFactory = fluentCfg.BuildSessionFactory();
      _session = _sessionFactory.OpenSession();
    }

    public void Save(object toSave)
    {
      _session.Save(toSave);
    }

    public void BeginTransaction()
    {
      OpenSession();
      _session.BeginTransaction();
    }

    public void Commit()
    {
      _session.Transaction.Commit();
    }

    public void Rollback()
    {
      _session.Transaction.Rollback();
    }

    public void CloseSession()
    {
      _session.Close();
    }

    public void CancelQuery()
    {
      _session.CancelQuery();
    }


    #region IDataAccessContext Members


    public string GetTableName(System.Type t)
    {
      return _cfg.GetClassMapping(t).Table.Name;
    }

    #endregion
  }
  
}
