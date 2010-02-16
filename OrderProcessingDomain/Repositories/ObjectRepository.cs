using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessingDomain
{
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

    public void Save(object toSave)
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

    public int Count()
    {
      return _list.Count;
    }

    #region IRepository<T> Members


    public T Get<T>(object key)
    {
      throw new NotImplementedException();
    }

    #endregion
  }

}
