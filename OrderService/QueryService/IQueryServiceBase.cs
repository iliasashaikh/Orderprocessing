using System;
using System.ServiceModel;

namespace OrderService.QueryService
{
  [ServiceContract]
  public interface IQueryServiceBase<T>
   where T : class
  {
    [OperationContract]
    System.Collections.Generic.IEnumerable<T> All();

    [OperationContract]
    long Count();
    
    [OperationContract]
    T First();
  }
}

