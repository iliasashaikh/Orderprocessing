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
  void Save();
}

public class NHRepository<T> : IRepository<T>
  where T: class
{

  IDataAccessContext dac = new NHDataAccessContext();

  public IEnumerable<T> GetAll()
  {
    using (ISession session = NHibernateHelper.OpenSession())
    {
      return session.Linq<T>();
    }
  }

  public IEnumerable<T> GetByCriteria(Func<T, bool> exp)
  {
    using (ISession session = NHibernateHelper.OpenSession())
    {
      return session.Linq<T>().Where<T>(exp);
    }
  }

  #region IRepository<T> Members

  public void Save()
  {
    throw new NotImplementedException();
  }


  public IDataAccessContext DataAccessContext
  {
    get
    {
      return dac;
    }
    set
    {
      dac = value;
    }
  }

  #endregion
}