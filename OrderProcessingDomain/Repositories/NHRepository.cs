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
    static NHDataAccessContext dac = new NHDataAccessContext();

    public IEnumerable<T> All()
    {
      dac.OpenSession();
      return dac.Session.Linq<T>();
    }

    public IEnumerable<T> Where(Func<T, bool> exp)
    {
      dac.OpenSession();
      return dac.Session.Linq<T>().Where(exp);
    }

    public void Remove(object toRemove)
    {
      dac.OpenSession();
      dac.Session.Delete(toRemove);
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

    public void Save(object toSave)
    {
      dac.OpenSession();
      dac.Session.Save(toSave);
    }

    public void Update(object toUpdate)
    {
      dac.OpenSession();
      dac.Session.Update(toUpdate);
    }

    public void RemoveWhere(Func<T, bool> exp)
    {
      dac.OpenSession();
      var recordsToDelete = dac.Session.Linq<T>().Where(exp);
      foreach (T o in recordsToDelete)
      {
        dac.Session.Delete(o);
      }
    }

  }
}
