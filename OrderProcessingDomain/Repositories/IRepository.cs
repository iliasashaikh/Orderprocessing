﻿using System.Linq;
using System.Linq.Expressions;
using System;
using NHibernate;
using NHibernate.Linq;

using OrderProcessingDomain;
using System.Collections.Generic;
using System.Collections;
using OrderProcessingDomain.Repositories;

public interface IRepository<T> where T : class
{
  IEnumerable<T> All();
  IEnumerable<T> Where(Expression< Func<T, bool>> exp);
  IDataAccessContext DataAccessContext{get;set;}
  void Remove(object toRemove);
  void Save(object toSave);
  void Update(object toUpdate);
  void RemoveWhere(Func<T, bool> exp);
  Int64 Count();
  T Get<T>(object key);
  void AddCustomColumn(string fieldName, CustomColumnType type);
}