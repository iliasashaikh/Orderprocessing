using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Mapping;
using NHibernate;

namespace OrderProcessingDomain
{
  public class OrderDetail
  {

    //int _orderId;

    //public int OrderId
    //{
    //  get { return ParentOrder.OrderId.Value; }
    //}


    //public virtual int OrderId { get; set; }
    public virtual int OrderDetailId { get; set; }
    public virtual Order ParentOrder { get; set; }
    public virtual Product ParentProduct { get; set; }
    //public virtual int ProductId { get; set; }
    public virtual decimal UnitPrice { get; set; }
    public virtual int Quantity { get; set; }
    public virtual decimal Discount { get; set; }

    public override bool Equals(object obj)
    {
      OrderDetail other = obj as OrderDetail;
      if (other != null)
      {
        return (this.ParentOrder.OrderId == other.ParentOrder.OrderId && this.ParentProduct.ProductId == other.ParentProduct.ProductId);
      }
      return false;
    }

    public override int GetHashCode()
    {
      return ParentOrder.OrderId.GetHashCode() + ParentProduct.ProductId.GetHashCode();
    }
  }

  public class OrderDetailsMap : ClassMap<OrderDetail>
  {
    public OrderDetailsMap()
    {
      Table("[Order Details]");
      Id(x => x.OrderDetailId).GeneratedBy.Identity().Column("OrderDetailID");
      References(x => x.ParentOrder).Column("OrderId");
      References(x => x.ParentProduct).Column("ProductId");
      Map(x => x.Discount);
      //Map(x => x.ProductId);
      Map(x => x.Quantity);
      Map(x => x.UnitPrice);
    }
  }

}
