using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OrderProcessingDomain;
using System.Threading;

namespace OrderService
{
  // NOTE: If you change the class name "Status" here, you must also update the reference to "Status" in App.config.
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode=ConcurrencyMode.Multiple)]
  public class Status : IStatus
  {
    public IEnumerable<Order> GetAllOrders()
    {
      try
      {
        IOC.RegisterComponents();
        return Repository<Order>.All(Thread.CurrentContext.ContextID);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }

      return null;
    }
  }
}
