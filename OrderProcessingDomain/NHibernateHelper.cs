using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace OrderProcessingDomain
{
  public class NHibernateHelper
  {
    public static ISession OpenSession()
    {
      return 
       (new NHibernate.Cfg.Configuration()
          .Configure()
          .AddAssembly(typeof(Order).Assembly)
          .BuildSessionFactory()
          .OpenSession());
    }

    public static ISession OpenSessionFluently()
    {
        try
        {
          return 

           Fluently.Configure()
             .Database(MsSqlConfiguration.MsSql2005.ConnectionString(c=>c.FromAppSetting("connectionString"))
             .ShowSql())
             .Mappings(m=>m.FluentMappings.AddFromAssemblyOf<OrderMap>())
             .BuildSessionFactory()
             .OpenSession();
        }
        catch (Exception ex)
        {
          throw;
        }
    }

    public static ISession OpenSessionFluentAndHbm()
    {
      try
      {
        return

         Fluently.Configure()
           .Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c.FromAppSetting("connectionString"))
           .ShowSql())
           .Mappings(m => m.HbmMappings.AddFromAssemblyOf<Order>())
           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>())
           .BuildSessionFactory()
           .OpenSession();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }

  public interface IOrderData
  {
    Order Load(Criteria c);
    IEnumerable<Order> Load

    void 
  }
}
