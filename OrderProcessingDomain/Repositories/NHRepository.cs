using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace OrderProcessingDomain
{
  public class NHRepository<T> : IRepository<T>
  where T : class
  {
    static NHDataAccessContext _dac;

    public NHRepository(NHDataAccessContext dac)
    {
      if (_dac == null)
        _dac = dac;
    }

    public NHRepository()
    {
    }

    public IEnumerable<T> All()
    {
      try
      {
        _dac.OpenSession();
        return _dac.Session.Linq<T>();
      }
      catch (Exception ex)
      {
      }
      return null;
    }

    public IEnumerable<T> Where(Expression<Func<T, bool>> exp)
    {
      _dac.OpenSession();
      IQueryable<T> result = _dac.Session.Linq<T>().Where(exp);
      return result.Where(exp);
    }

    public void Remove(object toRemove)
    {
      _dac.OpenSession();
      _dac.Session.Delete(toRemove);
      _dac.Session.Flush();
    }

    public void BeginTransaction()
    {
      _dac.BeginTransaction();
    }

    public void Commit()
    {
      _dac.Commit();
    }

    public void Rollback()
    {
      _dac.Rollback();
    }

    public IDataAccessContext DataAccessContext
    {
      get
      {
        return _dac;
      }
      set
      {
        _dac = (NHDataAccessContext)value;
      }
    }

    public void Save(object toSave)
    {
      _dac.OpenSession();
      _dac.Session.Save(toSave);
      _dac.Session.Flush();
    }

    public void Update(object toUpdate)
    {
      _dac.OpenSession();
      _dac.Session.Update(toUpdate);
    }

    public void RemoveWhere(Func<T, bool> exp)
    {
      _dac.OpenSession();
      var recordsToDelete = _dac.Session.Linq<T>().Where(exp);
      foreach (T o in recordsToDelete)
      {
        _dac.Session.Delete(o);
      }
    }

    public long Count()
    {
      _dac.OpenSession();
      return _dac.Session.Linq<T>().Count();
    }

    #region IRepository<T> Members


    public T Get<T>(object key)
    {
      _dac.OpenSession();
      return _dac.Session.Get<T>(key);
    }

    #endregion

    
  }
}
