using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderProcessingDomain;

namespace OrderService.QueryService
{
  public class QueryServiceBase<T>
    where T : class
  {
    protected IEnumerable<T> All()
    {
      IOC.RegisterComponents();
      return Repository<T>.All(Utils.GetContextId());
    }

    //IEnumerable<T> Where()
    //{
    //  IOC.RegisterComponents();
    //  return Repository<T>.Where();
    //}

    protected T First()
    {
      IOC.RegisterComponents();
      return Repository<T>.First(Utils.GetContextId());
    }

    protected Int64 Count()
    {
      IOC.RegisterComponents();
      return Repository<T>.Count(Utils.GetContextId());
    }
  }
}
