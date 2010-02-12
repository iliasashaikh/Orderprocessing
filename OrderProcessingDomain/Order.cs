using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate.Validator.Constraints;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace OrderProcessingDomain
{
  [DataContract]
  public class Order
  {
    [DataMember]
    public virtual int? OrderId{get;set;}
    
    [NotNull]
    //[DataMember]
    public virtual Customer Customer { get; set; }

    [NotNull]
    //[DataMember]
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

  }

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

    [DataMember]
    public virtual IList<Order> Orders { get; set; }
  }

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

    [DataMember]
    public virtual IList<Order> Orders { get; set; }
  }
}