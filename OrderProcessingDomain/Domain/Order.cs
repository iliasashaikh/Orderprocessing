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
using System.Reflection;

namespace OrderProcessingDomain
{
  [DataContract]
  [ServiceKnownType(typeof(Customer))]
  public class Order : EntityBase
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

    //[DataMember]
    //public virtual Hashtable CustomFields { get; set; }

    //string _dynamicColumnString = "";
    //[DataMember]
    //public virtual string CustomColumnString
    //{
    //  get
    //  {
    //    StringBuilder builder = new StringBuilder();

    //    foreach (DictionaryEntry entry in CustomFields)
    //    {
    //      builder.AppendFormat(@"{0}:{1};", entry.Key, entry.Value);
    //    }
    //    _dynamicColumnString = builder.ToString();
    //    return _dynamicColumnString;
    //  }
    //  set 
    //  {
    //    _dynamicColumnString = value;
    //  }
    //}

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

  [DataContract]
  public class DynamicColumn
  {
    [DataMember]
    public virtual Hashtable Fields { get; set; }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();

      foreach (DictionaryEntry entry in Fields)
      {
        builder.AppendFormat(@"{0}:{1};",entry.Key,entry.Value);
      }
      return builder.ToString();
    }
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

      DynamicComponent(x => x.CustomFields, (Action<DynamicComponentPart<IDictionary>>)Common.Util.MapDynamicColumns);
    }

    private void MapDynamicColumns(DynamicComponentPart<System.Collections.IDictionary> m)
    {
      //foreach(col in columns)
      //{
      //  m.Map(Common.Util.CreateExpression("x",colname,coltype));
      //}
      string s = m.EntityType.FullName;
      FieldInfo fi = m.GetType().GetField("entity", BindingFlags.Instance | BindingFlags.NonPublic);
      object o = fi.GetValue(m);
      string className = o.GetType().Name;
      m.Map(Common.Util.CreateExpression("x", "OrderDate", Type.GetType("System.DateTime")));
      m.Map(Common.Util.CreateExpression("x", "CustomField1", Type.GetType("System.String")));
      m.Map(Common.Util.CreateExpression("x", "CustomField2", Type.GetType("System.Int32")));
    }

    string s = @"<CustomFields>
                  <Class name=""Orders"" table=""Orders"">
                    <Columms>
                      <Column name=""OrderDate"" type=""System.DateTime""/>
                    </Columns>    
                  </Class>
                </CustomFields>
      ";

    //Expression<Func<IDictionary, object>> CreateExpression(string dictionaryName, string fieldName, Type fieldType)
    //{
    //  if (String.IsNullOrEmpty(dictionaryName))
    //    throw new ArgumentException("dictionaryName is null or empty.", "dictionaryName");
    //  if (String.IsNullOrEmpty(fieldName))
    //    throw new ArgumentException("fieldName is null or empty.", "fieldName");
    //  if (fieldType == null)
    //    throw new ArgumentNullException("fieldType", "fieldType is null.");

    //  Expression paramName = Expression.Constant("OrderDate", Type.GetType("System.String"));
    //  ParameterExpression dictName = Expression.Parameter(Type.GetType("System.Collections.IDictionary"), "x");
    //  Expression methodCall = Expression.Call(dictName, Type.GetType("System.Collections.IDictionary").GetMethod("get_Item"), new Expression[] { paramName });
    //  Expression unaryConvert = Expression.MakeUnary(ExpressionType.Convert, methodCall, Type.GetType("System.DateTime"));
    //  Expression convertAgain = Expression.MakeUnary(ExpressionType.Convert, unaryConvert, Type.GetType("System.Object"));
    //  Expression<Func<IDictionary, object>> convert = Expression.Lambda<Func<IDictionary, object>>(convertAgain, new ParameterExpression[] { dictName });

    //  return convert;
    //}

    void Act(DynamicComponentPart<IDictionary> dict)
    {
    }
  }



}