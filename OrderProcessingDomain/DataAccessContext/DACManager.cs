using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessingDomain
{
  public enum DACType
  {
    NH,
    Objects
  }

  public class DACManager
  {
    public static Dictionary<object,IDataAccessContext> _dacMap = new Dictionary<object,IDataAccessContext>() ;
    public static DACType DacType { get; set; }

    public DACManager()
    {
    }

    public static void Configure()
    {
    }

    public static void OpenSession(object owner)
    {
      IDataAccessContext dac;

      if (DacType == DACType.NH)
      {
        dac = new NHDataAccessContext();
        dac.OpenSession();
        _dacMap.Add(owner, dac);
      }
    }

    public static void CloseSession(object owner)
    {
      IDataAccessContext dac = GetCurrentSession(owner);
      dac.CloseSession();    
    }

    public static IDataAccessContext GetCurrentSession(object owner)
    {
      if (!_dacMap.Keys.Contains(owner) || _dacMap[owner] == null)
      {
        OpenSession(owner);
        return GetCurrentSession(owner);
      }
      else
        return _dacMap[owner];
    }

    public static void BeginTransaction(object owner)
    {
      IDataAccessContext dac = GetCurrentSession(owner);
      dac.BeginTransaction();
    }

    public static void Commit(object owner)
    {
      IDataAccessContext dac = GetCurrentSession(owner);
      dac.Commit();
    }

    public static void Rollback(object owner)
    {
      IDataAccessContext dac = GetCurrentSession(owner);
      dac.Rollback();
    }
  }
}