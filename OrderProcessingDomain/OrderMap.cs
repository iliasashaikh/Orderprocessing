using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate;

namespace OrderProcessingDomain
{

  public class OrderDetailsMap : ClassMap<OrderDetails>
  {
    public OrderDetailsMap()
    {
      Table("[Order Details]");
      CompositeId().KeyProperty(x => x.OrderId).KeyProperty(x => x.ProductId);
      //Id(x => x.OrderId).GeneratedBy.Assigned();
      References(x => x.ParentOrder).Column("OrderId").Not.Nullable().Cascade.None();
      Map(x => x.Discount);
      Map(x => x.ProductId);
      Map(x => x.Quantity);
      Map(x => x.UnitPrice);
    }
  }

  public class OrderMap : ClassMap<Order>
  {
    public OrderMap()
    {
      Table("Orders");
      Id(x => x.OrderId).GeneratedBy.Identity();
      HasMany<OrderDetails>(x => x.Details).KeyColumn("OrderId").Cascade.AllDeleteOrphan().Inverse();
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
      References(x => x.Customer).Column("CustomerId").Cascade.SaveUpdate();
      References(x => x.Employee).Column("EmployeeId").Cascade.SaveUpdate();
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
