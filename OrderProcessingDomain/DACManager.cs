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

  class DACManager
  {
    public static Dictionary<object,IDataAccessContext> _dacMap = new Dictionary<object,IDataAccessContext>() ;
    public static DACType DacType { get; set; }

    public DACManager()
    {
    }

    public static void Configure()
    {
    }

    public static void OpenSession(object dacOwner)
    {
      IDataAccessContext dac;

      if (DacType == DACType.NH)
      {
        dac = new NHDataAccessContext();
        dac.OpenSession();
        _dacMap.Add(dacOwner, dac);
      }
    }

    public static void CloseSession(object dacOwner)
    {
           
    }

    public static IDataAccessContext GetCurrentSession(object dacOwner)
    {
      return _dacMap[dacOwner];
    }

    public static void BeginTransaction(object dacOwner)
    {
      IDataAccessContext dac = GetCurrentSession(dacOwner);
      dac.BeginTransaction();
    }

    public static void Commit(object dacOwner)
    {
      IDataAccessContext dac = GetCurrentSession(dacOwner);
      dac.Commit();
    }

    public static void Rollback(object dacOwner)
    {
      IDataAccessContext dac = GetCurrentSession(dacOwner);
      dac.Rollback();
    }
  }
}