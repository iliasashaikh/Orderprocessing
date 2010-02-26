using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderProcessingDomain;

using System.ServiceModel;

namespace OrderService.QueryService
{
  [ServiceContract]
  public interface ICustomerQueryService : IQueryServiceBase<Customer>
  {
  }
}
