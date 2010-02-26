using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderProcessingDomain;

namespace OrderProcessing.Classes
{
  public class Query
  {
    public Customer[] GetAllCustomers(ServiceClient client)
    {
      return client.CustomerQueryClient.All();
    }

    public Order[] GetAllOrders(ServiceClient client)
    {
      return client.OrderQueryClient.All();
    }

    public Employee[] GetAllEmployees(ServiceClient client)
    {
      return client.EmployeeQueryClient.All();
    }

  }
}
