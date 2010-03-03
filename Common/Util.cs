using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Common
{
  public class Util
  {
    const string CONTEXT_KEY = "contextkey";

    public static string GetContextId()
    {
      if (OperationContext.Current != null)
      {
        ContextMessageProperty messageProperty = OperationContext.Current.IncomingMessageProperties[ContextMessageProperty.Name] as ContextMessageProperty;
        if (messageProperty != null && messageProperty.Context.ContainsKey(CONTEXT_KEY))
        {
          string contextId = messageProperty.Context[CONTEXT_KEY];
          if (!String.IsNullOrEmpty(contextId))
            return contextId;
        }
      }

      return Thread.CurrentContext.ContextID.ToString();
    }

    public static void SetContextId(IClientChannel innerChannel, string contextId)
    {
      IContextManager cntxManager = innerChannel.GetProperty<IContextManager>();
      IDictionary<string, string> context = cntxManager.GetContext();
      context.Add(CONTEXT_KEY, contextId);
      cntxManager.SetContext(context);
    }

    public static void AssignContextId(IClientChannel innerChannel)
    {
      string contextId = Guid.NewGuid().ToString();
      Common.Util.SetContextId(innerChannel, contextId);
    }
  }
}
