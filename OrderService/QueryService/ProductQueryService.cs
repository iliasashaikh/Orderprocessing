using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderProcessingDomain;
using System.ServiceModel;

namespace OrderService.QueryService
{
  public class ProductQueryService : QueryServiceBase<Product>, IProductQueryService
  {
  }
}
