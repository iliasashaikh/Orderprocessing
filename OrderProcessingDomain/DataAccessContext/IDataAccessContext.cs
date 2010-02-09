using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;

using System.Threading;
using System.Collections;

namespace OrderProcessingDomain
{
  public interface IDataAccessContext
  {
    void OpenSession();
    void BeginTransaction();
    void Save(object toSave);
    void Commit();
    void Rollback();
    void CloseSession();
    void CancelQuery();
  }
}
