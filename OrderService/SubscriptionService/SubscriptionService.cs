using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;

namespace OrderService.SubscriptionService
{
  public class SubscriptionService : ISubscriptionService
  {
    #region ISubscriptionService Members

    static List<INotification> _subscribers = new List<INotification>();

    public void Subscribe()
    {
      INotification notificationClient = OperationContext.Current.GetCallbackChannel<INotification>();
      _subscribers.Add(notificationClient);
    }

    public void UnSubscribe()
    {
      INotification notificationClient = OperationContext.Current.GetCallbackChannel<INotification>();
      _subscribers.Remove(notificationClient);
    }

    public static void NotifyAll(string message)
    {
      ThreadPool.QueueUserWorkItem((state) =>
      {
        foreach (INotification subscriber in _subscribers)
          subscriber.Notify(message);
      }
      );
        //ThreadPool.QueueUserWorkItem((state) =>
        //{
        //  try
        //  {
        //    subscriber.Notify(message);
        //  }
        //  catch (Exception ex)
        //  {
        //    Common.Util.LogMessageToEventLog(ex.Message);     
        //  }
        //});
    }

    #endregion
  }
}
