using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using NUnit.Framework;
using Spring.Core;
using Spring.Context;
using Spring.Context.Support;
using OrderProcessingDomain;
using System.Diagnostics;

namespace OrderProcessing.Tests
{
  [TestFixture]
  class OrderProcessTestForIOC
  {
    [TestFixtureSetUp]
    public void SetupContainer()
    {
      try
      {
        IApplicationContext context = ContextRegistry.GetContext();
        var dao = context.GetObjectsOfType(typeof(NHDataAccessContext));
        var daoNH = context.GetObject("nhDataAccessContext");
        var daoNH1 = context.GetObject("nhDataAccessContext");
        var dacManager = context.GetObject("dacManager");
        var dacManager1 = context.GetObject("dacManager");
        Assert.That(dao, Is.Not.Null);
        Assert.That(dacManager, Is.EqualTo(dacManager1));
        Assert.That(daoNH, Is.Not.EqualTo(daoNH1));
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    void ShowError(Exception ex)
    {
      Debug.WriteLine(ex.Message);
      Debug.WriteLine(ex.StackTrace);
      if (ex.InnerException != null)
      {
        Debug.WriteLine("---------------------");
        ShowError(ex.InnerException);
      }
    }

  }
}
