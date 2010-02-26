using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderProcessingDomain;

namespace OrderService.QueryService
{
  [ServiceContract]
  public interface IOrderQueryService : IQueryServiceBase<Order>
  {
  }
}
