using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;
using OrderProcessingDomain.Repositories;

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

    public void AddCustomColumn(string fieldName, CustomColumnType type)
    {
      _dac.OpenSession();
      Type t = typeof(Repository<T>).GetGenericArguments()[0];
      string tableName = _dac.GetTableName(t);
      string query = CreateQuery(tableName, fieldName, type);
      ISQLQuery sqlQuery = _dac.Session.CreateSQLQuery(query);
      sqlQuery.ExecuteUpdate();
    }

    string CreateQuery(string tableName, string fieldName, CustomColumnType type)
    {

      string sqlType = GetSQLType(type);
      string query = String.Format(@"If Not Exists
                                    (
                                      Select * from INFORMATION_SCHEMA.COLUMNS
                                      where TABLE_NAME = '{0}' and COLUMN_NAME = '{1}'
                                    )
                                      ALTER TABLE {0} ADD {1} {2} NULL;", tableName, fieldName, sqlType);
      return query;
    }

    private string GetSQLType(CustomColumnType type)
    {
      string sqlType = "varchar(255)";
      switch (type)
      {
        case CustomColumnType.DateTime:
          sqlType = "datetime";
          break;
        case CustomColumnType.Integer:
          sqlType = "int";
          break;
        case CustomColumnType.Numeric:
          sqlType = "numeric(28, 8)";
          break;
      }
      return sqlType;
    }


  }
}
