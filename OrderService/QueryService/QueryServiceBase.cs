﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;

using ExpressionSerialization;

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
      return Repository<T>.All(Common.Util.GetContextId()).Reverse();
    }

    public T First()
    {
      IOC.RegisterComponents();
      return Repository<T>.First(Common.Util.GetContextId());
    }

    public Int64 Count()
    {
      IOC.RegisterComponents();
      return Repository<T>.Count(Common.Util.GetContextId());
    }


    public T Where(System.Xml.Linq.XElement serializedExpression)
    {
      ExpressionSerialization.ExpressionSerializer serializer = new ExpressionSerializer();
      Expression<Func<T,bool>> exp = serializer.Deserialize<Func<T, bool>>(serializedExpression);
      return Repository<T>.Where(exp,Common.Util.GetContextId()).First();
    }

    public IEnumerable<T> WhereAll(System.Xml.Linq.XElement serializedExpression)
    {
      ExpressionSerialization.ExpressionSerializer serializer = new ExpressionSerializer();
      Expression<Func<T, bool>> exp = serializer.Deserialize<Func<T, bool>>(serializedExpression);
      return Repository<T>.Where(exp, Common.Util.GetContextId());
    }
  }
}
