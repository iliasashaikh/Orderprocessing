using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessing.Classes
{
  public class NotificationHandler : SubscriptionServiceReference.ISubscriptionServiceCallback
  {
    #region ISubscriptionServiceCallback Members
    public delegate void NotificationDelegate(string message);

    public event NotificationDelegate NotifyClient;

    public void Notify(string message)
    {
      NotifyClient(message);
    }

    public IAsyncResult BeginNotify(string message, AsyncCallback callback, object asyncState)
    {
      throw new NotImplementedException();
    }

    public void EndNotify(IAsyncResult result)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
