using System.Linq;
using System;
using NHibernate;
using NHibernate.Linq;

using OrderProcessingDomain;
using System.Collections.Generic;

public interface IRepository<T> where T : class
{
  IEnumerable<T> GetAll();
  IEnumerable<T> GetByCriteria(Func<T, bool> f);
  IDataAccessContext DataAccessContext{get;set;}
  void Save(object toSave);
}

public class ObjectRepository<T> : IRepository<T>
{

}

public class NHRepository<T> : IRepository<T>
  where T: class
{
  static NHDataAccessContext dac = new NHDataAccessContext();

  public IEnumerable<T> GetAll()
  {
    dac.OpenSession();
    return dac.Session.Linq<T>();
  }

  public IEnumerable<T> GetByCriteria(Func<T, bool> exp)
  {
    dac.OpenSession();
    return dac.Session.Linq<T>().Where(exp);
  }

  public void Save(object toSave)
  {
    dac.OpenSession();
    dac.Save(toSave);
  }

  public void BeginTransaction()
  {
    dac.BeginTransaction();
  }

  public void Commit()
  {
    dac.Commit();
  }

  public void Rollback()
  {
    dac.Rollback();
  }

  public IDataAccessContext DataAccessContext
  {
    get
    {
      return dac;
    }
    set
    {
      dac = (NHDataAccessContext)value;
    }
  }
}