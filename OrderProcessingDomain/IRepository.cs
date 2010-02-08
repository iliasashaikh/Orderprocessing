using System.Linq;
using System;
using NHibernate;
using NHibernate.Linq;

using OrderProcessingDomain;
using System.Collections.Generic;
using System.Collections;

public interface IRepository<T> where T : class
{
  IEnumerable<T> All();
  IEnumerable<T> Where(Func<T, bool> exp);
  IDataAccessContext DataAccessContext{get;set;}
  void Remove(object toRemove);
  void Add(object toSave);
  void Update(object toUpdate);
  void RemoveWhere(Func<T, bool> exp);
}

public class ObjectRepository<T> : IRepository<T>
  where T : class
{

  static ObjectDataAccessContext dac = new ObjectDataAccessContext();
  List<T> _list;

  public ObjectRepository()
  {
    List<T> list = new List<T>();
    _list = list;
    dac.SetupData(list);
  }

  public ObjectRepository(List<T> list)
  {
    _list = list;
    dac.SetupData(list);
  }


  public IEnumerable<T> All()
  {
    return _list;
  }

  public IEnumerable<T> Where(Func<T, bool> exp)
  {
    return _list.Where<T>(exp);
  }

  public void Add(object toSave)
  {
    T obj = toSave as T;
    T existingObj;
    if (obj != null)
    {
      //check if the object already exists
      if (_list.Exists
          (
            o =>
            {
              if (o == obj)
              {
                existingObj = obj;
                return true;
              }
              return false;
            }
          )
        )
        existingObj = (T)toSave;
      else
        //this is a new object, its obviously necessary to override the Equals property with a business key in order to make this work
        _list.Add((T)toSave);
    }
  }

  public void Remove(object toRemove)
  {
    T obj = toRemove as T;
    if (obj != null)
      _list.Remove(obj);
  }

  public void RemoveWhere(Func<T, bool> exp)
  {
    var itemsToRemove = _list.Where(exp);
    foreach (T item in itemsToRemove)
    {
      _list.Remove(item);
    }
  }

  public IDataAccessContext DataAccessContext
  {
    get
    {
      return dac;
    }
    set
    {
      dac = (ObjectDataAccessContext)value;
    }
  }

  public void Update(object toUpdate)
  {
    T existingObject;
    if (_list.Exists
          (
            o =>
            {
              if (o.GetHashCode() == toUpdate.GetHashCode())
                return true;
              if (o == toUpdate)
              {
                existingObject = o;
                return true;
              }
              return false;
            }
          )
        )
    {
      existingObject = (T)toUpdate;
    }
    else
      _list.Add((T)toUpdate);

  }
}

public class NHRepository<T> : IRepository<T>
  where T: class
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

  public void Add(object toSave)
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