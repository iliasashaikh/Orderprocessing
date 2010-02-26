using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using OrderProcessingDomain;

namespace OrderService.QueryService
{
  [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Single,InstanceContextMode=InstanceContextMode.PerSession)]
  public class QueryServiceBase<T> : IQueryServiceBase<T>
    where T : class
  {
    public IEnumerable<T> All()
    {
      IOC.RegisterComponents();
      return Repository<T>.All(Utils.GetContextId());
    }

    public T First()
    {
      IOC.RegisterComponents();
      return Repository<T>.First(Utils.GetContextId());
    }

    public Int64 Count()
    {
      IOC.RegisterComponents();
      return Repository<T>.Count(Utils.GetContextId());
    }
  }
}
