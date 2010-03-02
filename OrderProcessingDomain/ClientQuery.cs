using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrderProcessingDomain
{
  public class ClientQuery<T> : IQueryable<T> , IQueryProvider
  {
    Expression _expression;

    public ClientQuery()
    {
      _expression = Expression.Constant(this);
    }

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IQueryable Members

    public Type ElementType
    {
      get { throw new NotImplementedException(); }
    }

    public System.Linq.Expressions.Expression Expression
    {
      get { return _expression; }
    }

    public IQueryProvider Provider
    {
      get { return this; }
    }

    #endregion

    #region IQueryProvider Members

    public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
    {
      return new ClientQuery<TElement>() { _expression = expression};
    }

    public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
    {
      throw new NotImplementedException();
    }

    public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
    {
      throw new NotImplementedException();
    }

    public object Execute(System.Linq.Expressions.Expression expression)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
