using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate;
using System.Runtime.Serialization;

namespace OrderProcessingDomain
{

  [DataContract]
  public class Product
  {
    [DataMember]
    public virtual int ProductId { get; set; }
    [DataMember]
    public virtual string ProductName { get; set; }
    [DataMember]
    public virtual int SupplierID { get; set; }
    [DataMember]
    public virtual int CategoryID { get; set; }
    [DataMember]
    public virtual string QuantityPerUnit { get; set; }
    [DataMember]
    public virtual double UnitPrice { get; set; }
    [DataMember]
    public virtual int UnitsInStock { get; set; }
    [DataMember]
    public virtual int UnitsOnOrder { get; set; }
    [DataMember]
    public virtual int ReorderLevel { get; set; }
    [DataMember]
    public virtual bool Discontinued { get; set; }
  }

  public class ProductsMap : ClassMap<Product>
  {
    public ProductsMap()
    {
      Table("Products");
      Id(x => x.ProductId).GeneratedBy.Identity();
      Map(x => x.ProductName);
      Map(x => x.QuantityPerUnit);
      Map(x => x.ReorderLevel);
      Map(x => x.SupplierID);
      Map(x => x.CategoryID);
      Map(x => x.UnitPrice);
      Map(x => x.UnitsInStock);
      Map(x => x.UnitsOnOrder);
      Map(x => x.Discontinued);
    }
  }

}
