using System;
using System.ServiceModel;
using System.Xml.Linq;

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

    [OperationContract]
    T Where(XElement serializedExpression);

    [OperationContract]
    System.Collections.Generic.IEnumerable<T> WhereAll(XElement serializedExpression);
  }
}

