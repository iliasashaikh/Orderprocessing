using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using OrderProcessingDomain;

namespace OrderService.QueryService
{
  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]
  public class OrderQueryService : QueryServiceBase<Order>, IOrderQueryService
  {
  }
}
