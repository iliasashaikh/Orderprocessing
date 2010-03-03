using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Threading;

namespace OrderService
{
  public static class Utils
  {
    public static string GetContextId()
    {
      //if (OperationContext.Current == null)
      //  return Thread.CurrentContext.ContextID.ToString();
      //else
      //  return OperationContext.Current.SessionId;

      return Thread.CurrentContext.ContextID.ToString();

    }
  }
}
