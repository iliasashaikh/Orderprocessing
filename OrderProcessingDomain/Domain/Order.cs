using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate.Validator.Constraints;
using System.ServiceModel;
using System.Runtime.Serialization;

using FluentNHibernate.Mapping;
using NHibernate;
using System.Linq.Expressions;

namespace OrderProcessingDomain
{
  [DataContract]
  [ServiceKnownType(typeof(Customer))]
  public class Order
  {
    [DataMember]
    public virtual int? OrderId{get;set;}
    
    [NotNull]
    [DataMember]
    public virtual Customer Customer { get; set; }

    [NotNull]
    [DataMember]
    public virtual Employee Employee { get; set; }

    [DataMember]
    public virtual DateTime? RequiredDate { get; set; }
    
    [DataMember]
    public virtual DateTime? ShippedDate { get; set; }
    
    [DataMember]
    public virtual int? Shipvia { get; set; }
    
    [DataMember]
    public virtual decimal Freight { get; set; }
    
    [DataMember]
    public virtual string ShipName { get; set; }
    
    [DataMember]
    public virtual string ShipAddress { get; set; }
    
    [DataMember]
    public virtual string ShipCity { get; set; }
    
    [DataMember]
    public virtual string ShipRegion { get; set; }
    
    [DataMember]
    public virtual string ShipPostalCode { get; set; }

    [DataMember]
    public virtual string ShipCountry { get; set; }

    [DataMember]
    public virtual Hashtable CustomFields { get; set; }

    public override bool Equals(object obj)
    {
      if ((obj as Order) != null)
      {
        return (((Order)obj).OrderId == this.OrderId);
      }

      return false;
    }

    public virtual IList<OrderDetail> Details { get; set; }

  }

  public class OrderMap : ClassMap<Order>
  {

    public OrderMap()
    {
      Table("Orders");
      Id(x => x.OrderId).GeneratedBy.Identity();
      //HasMany<OrderDetails>(x => x.Details).KeyColumn("OrderId").Cascade.AllDeleteOrphan().Inverse();
      //HasMany<OrderDetails>(x => x.Details).KeyColumn("OrderId").Cascade.AllDeleteOrphan().Inverse();
      //References(x => x.Details).Cascade.All().Column("OrderId").NotFound.Ignore();
      //Map(x => x.OrderDate);
      Map(x => x.RequiredDate);
      Map(x => x.ShipAddress);
      Map(x => x.ShipCity);
      Map(x => x.ShipCountry);
      Map(x => x.ShipName);
      Map(x => x.ShippedDate);
      Map(x => x.ShipPostalCode);
      Map(x => x.ShipRegion);
      Map(x => x.Shipvia);
      References(x => x.Customer).Column("CustomerId").Cascade.SaveUpdate().Not.LazyLoad();
      References(x => x.Employee).Column("EmployeeId").Cascade.SaveUpdate().Not.LazyLoad();

      DynamicComponent(x => x.CustomFields, (Action<DynamicComponentPart<IDictionary>>)MapDynamicColumns);
      //DynamicComponent(x => x.CustomFields, MapDynamicComponents());
    }

    private static void MapDynamicColumns(DynamicComponentPart<System.Collections.IDictionary> m)
    {
      //m.Map(x => x["OrderDate"]);
      m.Map("OrderDate");
      //m.Map(x => Convert.ChangeType(x["OrderDate"], Type.GetType("System.DateTime")));

    }

    string s = @"<CustomFields>
                  <Class name=""Orders"" table = ""Orders"">
                    <Columms>
                      <Column name=""""OrderDate"""" type=""System.DateTime"" value=""0""/>
                      <Column name=""""OrderDate"""" type=""System.DateTime"" value=""0""/>
                    </Columns>    
                  </Class>
                </CustomFields>
      ";

    //Action<DynamicComponentPart<IDictionary>> MapDynamicComponents()
    //{
    //  return new Action<DynamicComponentPart<IDictionary>>(Act);
    //}

    void Act(DynamicComponentPart<IDictionary> dict)
    {
    }
  }



}