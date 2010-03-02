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

namespace OrderProcessingDomain
{
  [DataContract]
  public class Employee
  {
    [DataMember]
    public virtual int? EmployeeId { get; set; }

    [DataMember]
    public virtual string LastName { get; set; }

    [DataMember]
    public virtual string FirstName { get; set; }

    [DataMember]
    public virtual string Title { get; set; }

    [DataMember]
    public virtual string TitleOfCourtesy { get; set; }

    [DataMember]
    public virtual DateTime? BirthDate { get; set; }

    [DataMember]
    public virtual DateTime? HireDate { get; set; }

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
    public virtual string HomePhone { get; set; }

    [DataMember]
    public virtual string Extension { get; set; }

    [DataMember]
    public virtual Employee ReportsTo { get; set; }

    [DataMember]
    public virtual string PhotoPath { get; set; }

    [DataMember]
    public virtual byte[] Photo { get; set; }

    //[DataMember]
    public virtual IList<Order> Orders { get; set; }

    public override bool Equals(object obj)
    {
      if ((obj as Employee) != null)
      {
        return (((Employee)obj).EmployeeId == this.EmployeeId);
      }

      return false;
    }

    public override string ToString()
    {
      return EmployeeId.ToString();
    }
  }

  public class EmployeeMap : ClassMap<Employee>
  {
    public EmployeeMap()
    {
      Table("Employees");
      Id(x => x.EmployeeId).GeneratedBy.Identity();
      Map(x => x.Address);
      Map(x => x.BirthDate);
      Map(x => x.City);
      Map(x => x.Country);
      Map(x => x.Extension);
      Map(x => x.FirstName);
      Map(x => x.HireDate);
      Map(x => x.HomePhone);
      Map(x => x.LastName);
      //Map(x => x.Notes);
      Map(x => x.Photo);
      Map(x => x.PhotoPath);
      Map(x => x.PostalCode);
      Map(x => x.Region);

      //References(x => x.ReportsTo).Column("EmployeeId");
      Map(x => x.Title);
      Map(x => x.TitleOfCourtesy);  

      HasMany(x => x.Orders).KeyColumn("EmployeeId");
    }
  }
}
