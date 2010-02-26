using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessing.Classes
{
  public class ServiceClient
  {
    CustomerQueryServiceReference.CustomerQueryServiceClient custQueryClient;

    public CustomerQueryServiceReference.CustomerQueryServiceClient CustomerQueryClient
    {
      get { return custQueryClient; }
      set { custQueryClient = value; }
    }

    OrderQueryServiceReference.OrderQueryServiceClient orderQueryClient;

    public OrderQueryServiceReference.OrderQueryServiceClient OrderQueryClient
    {
      get { return orderQueryClient; }
      set { orderQueryClient = value; }
    }

    EmployeeQueryServiceReference.EmployeeQueryServiceClient empQueryClient;

    public EmployeeQueryServiceReference.EmployeeQueryServiceClient EmployeeQueryClient
    {
      get { return empQueryClient; }
      set { empQueryClient = value; }
    }

    CommandServiceReference.CommandServiceClient cmdClient;

    public CommandServiceReference.CommandServiceClient CommandClient
    {
      get { return cmdClient; }
      set { cmdClient = value; }
    }

    public ServiceClient Initialise()
    {
      try
      {
        custQueryClient = new OrderProcessing.CustomerQueryServiceReference.CustomerQueryServiceClient();
        orderQueryClient = new OrderProcessing.OrderQueryServiceReference.OrderQueryServiceClient();
        empQueryClient = new OrderProcessing.EmployeeQueryServiceReference.EmployeeQueryServiceClient();
        cmdClient = new OrderProcessing.CommandServiceReference.CommandServiceClient();
      }
      catch (Exception ex)
      {
        throw;
      }

      return this;
    }
  }
}
