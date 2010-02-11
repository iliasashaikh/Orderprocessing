using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace OrderProcessingDomain
{
  public class NHRepository<T> : IRepository<T>
  where T : class
  {
    static NHDataAccessContext _dac = new NHDataAccessContext();

    public NHRepository(NHDataAccessContext dac)
    {
      _dac = dac;
    }

    public NHRepository()
    {
    }

    public IEnumerable<T> All()
    {
      _dac.OpenSession();
      return _dac.Session.Linq<T>();
    }

    public IEnumerable<T> Where(Func<T, bool> exp)
    {
      _dac.OpenSession();
      IQueryable<T> result = _dac.Session.Linq<T>();
      return result.Where(exp);
    }

    public void Remove(object toRemove)
    {
      _dac.OpenSession();
      _dac.Session.Delete(toRemove);
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

  }
}
