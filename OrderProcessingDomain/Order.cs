using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate.Validator.Constraints;

namespace OrderProcessingDomain
{
  public class Order
  {
    public virtual int? OrderId{get;set;}
    
    [NotNull]
    public virtual Customer Customer {get;set;}

    [NotNull]
    public virtual Employee Employee {get;set;}

    public virtual DateTime? RequiredDate { get; set; }
    public virtual DateTime? ShippedDate { get; set; }
    public virtual int? Shipvia { get; set; }
    public virtual decimal Freight { get; set; }
    public virtual string ShipName { get; set; }
    public virtual string ShipAddress { get; set; }
    public virtual string ShipCity { get; set; }
    public virtual string ShipRegion { get; set; }
    public virtual string ShipPostalCode { get; set; }
    public virtual string ShipCountry { get; set; }

    public virtual Hashtable CustomFields { get; set; }

  }

  public class Employee
  {
    public virtual int? EmployeeId { get; set; }
    public virtual string LastName { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string Title { get; set; }
    public virtual string TitleOfCourtesy { get; set; }
    public virtual DateTime? BirthDate { get; set; }
    public virtual DateTime? HireDate { get; set; }
    public virtual string Address { get; set; }
    public virtual string City { get; set; }
    public virtual string Region { get; set; }
    public virtual string PostalCode { get; set; }
    public virtual string Country { get; set; }
    public virtual string HomePhone { get; set; }
    public virtual string Extension { get; set; }
    public virtual string Notes { get; set; }
    public virtual Employee ReportsTo { get; set; }
    public virtual string PhotoPath { get; set; }
    public virtual byte[] Photo { get; set; }
    public virtual IList<Order> Orders { get; set; }
  }

  public class Customer
  {
    public virtual string CustomerId { get; set; }
    public virtual string CompanyName { get; set; }
    public virtual string ContactName { get; set; }
    public virtual string ContactTitle { get; set; }
    public virtual string Address { get; set; }
    public virtual string City { get; set; }
    public virtual string Region { get; set; }
    public virtual string PostalCode { get; set; }
    public virtual string Country { get; set; }
    public virtual string Phone { get; set; }
    public virtual string Fax { get; set; }

    public virtual IList<Order> Orders { get; set; }
  }
}