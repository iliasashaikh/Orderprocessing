using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate;

namespace OrderProcessingDomain
{
  public class OrderMap : ClassMap<Order>
  {
    public OrderMap()
    {
      Table("Orders");
      Id(x => x.OrderId);
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
      References(x => x.Customer).Column("CustomerId");
      References(x => x.Employee).Column("EmployeeId");
    }
  }

  public class CustomerMap : ClassMap<Customer>
  {
    public CustomerMap()
    {
      Table("Customers");
      Id(x => x.CustomerId).Column("CustomerId");
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

      HasMany(x => x.Orders).KeyColumn("CustomerId");
    }
  }

  public class EmployeeMap : ClassMap<Employee>
  {
    public EmployeeMap()
    {
      Table("Employees");
      Id(x => x.EmployeeId).Column("EmployeeId");
      Map(x => x.Address);
      Map(x => x.BirthDate);
      Map(x => x.City);
      Map(x => x.Country);
      Map(x => x.Extension);
      Map(x => x.FirstName);
      Map(x => x.HireDate);
      Map(x => x.HomePhone);
      Map(x => x.LastName);
      Map(x => x.Notes);
      Map(x => x.Photo);
      Map(x => x.PhotoPath);
      Map(x => x.PostalCode);
      Map(x => x.Region);

      References(x => x.ReportsTo).Column("EmployeeId");
      Map(x => x.Title);
      Map(x => x.TitleOfCourtesy);

      HasMany(x => x.Orders).KeyColumn("EmployeeId");
    }
  }
}
