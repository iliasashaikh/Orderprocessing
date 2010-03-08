using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OrderProcessingDomain.Repositories;

namespace OrderProcessingDomain
{
  public class Repository<T>
    where T : class
  {
    public IDataAccessContext DAC { get; set; }

    #region IRepository<T> Members

    private static IRepository<T> GetRepositoryFromContainer()
    {
      return IOC.Resolve<IRepository<T>>();
    }

    public static IEnumerable<T> All(object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.DataAccessContext = dac;
      return repo.All();
    }

    public static long Count(object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      return repo.Count();

    }

    public static IEnumerable<T> Where( Expression<Func<T, bool>> exp, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.DataAccessContext = dac;
      return repo.Where(exp);
    }

    public static void Remove(object toRemove, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.DataAccessContext = dac;
      repo.Remove(toRemove);
    }

    public static void Save(object toSave, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.DataAccessContext = dac;
      repo.Save(toSave);
    }

    public static void Update(object toUpdate, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.DataAccessContext = dac;
      repo.Update(toUpdate);
    }

    public static void RemoveWhere(Func<T, bool> exp, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.DataAccessContext = dac;
      repo.RemoveWhere(exp);
    }

    public static T Get(object key, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      return repo.Get<T>(key);
    }

    public static void AddCustomColumn(string fieldName, CustomColumnType type, object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      IRepository<T> repo = GetRepositoryFromContainer();
      repo.AddCustomColumn(fieldName, type);
    }

    #endregion

    public static T First(object owner)
    {
      throw new NotImplementedException();
    }
  }

  public class Repositiory
  {
    public static void Open(object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      dac.OpenSession();
    }

    public static void Close(object owner)
    {
      IDataAccessContext dac = DACManager.GetCurrentSession(owner);
      dac.CloseSession();
    }

    public static Type GetGenericType(Type t)
    {
      Type genericType = typeof(Repository<>);
      Type[] types = {t};
      return genericType.MakeGenericType(t);
    }
  }
 }


