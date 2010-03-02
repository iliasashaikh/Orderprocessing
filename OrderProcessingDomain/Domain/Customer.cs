using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using NHibernate;
using FluentNHibernate.Mapping;

namespace OrderProcessingDomain
{
  [DataContract]
  public class Customer
  {
    [DataMember]
    public virtual string CustomerId { get; set; }

    [DataMember]
    public virtual string CompanyName { get; set; }

    [DataMember]
    public virtual string ContactName { get; set; }

    [DataMember]
    public virtual string ContactTitle { get; set; }

    [DataMember]
    public virtual string Address { get; set; }

    [DataMember]
    public virtual string City { get; set; }

    [DataMember]
    public virtual string Region { get; set; }

    [DataMember]
    public virtual string PostalCode { get; set; }

    [DataMember]
    public virtual string Country { get; set; }

    [DataMember]
    public virtual string Phone { get; set; }

    [DataMember]
    public virtual string Fax { get; set; }

    //[DataMember]
    public virtual IList<Order> Orders { get; set; }

    public override bool Equals(object obj)
    {
      if ((obj as Customer) != null)
      {
        return String.Compare(((Customer)obj).CustomerId, this.CustomerId, true) == 0;
      }

      return false;
    }

    public override string ToString()
    {
      return CustomerId;
    }

  }

  public class CustomerMap : ClassMap<Customer>
  {
    public CustomerMap()
    {
      Table("Customers");
      Id(x => x.CustomerId).Column("CustomerId").GeneratedBy.Assigned();
      Map(x => x.Address);
      Map(x => x.City);
      Map(x => x.CompanyName);
      Map(x => x.ContactName);
      Map(x => x.ContactTitle);
      Map(x => x.Country);
      Map(x => x.Fax);
      Map(x => x.Phone);
      Map(x => x.PostalCode);
      Map(x => x.Region);

      HasMany(x => x.Orders).KeyColumn("CustomerId").Cascade.SaveUpdate();
    }
  }
}
