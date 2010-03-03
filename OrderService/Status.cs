using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OrderProcessingDomain;
using System.Threading;
using OrderService;

namespace OrderProcessingDomain
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
        return Repository<Order>.All(Common.Util.GetContextId());
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
