using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessing.Classes
{
  public class ServiceClient
  {
    CustomerQueryServiceReference.CustomerQueryServiceClient _custQueryClient;

    public CustomerQueryServiceReference.CustomerQueryServiceClient CustomerQueryClient
    {
      get { return _custQueryClient; }
      set { _custQueryClient = value; }
    }

    OrderQueryServiceReference.OrderQueryServiceClient _orderQueryClient;

    public OrderQueryServiceReference.OrderQueryServiceClient OrderQueryClient
    {
      get { return _orderQueryClient; }
      set { _orderQueryClient = value; }
    }

    EmployeeQueryServiceReference.EmployeeQueryServiceClient _empQueryClient;

    public EmployeeQueryServiceReference.EmployeeQueryServiceClient EmployeeQueryClient
    {
      get { return _empQueryClient; }
      set { _empQueryClient = value; }
    }

    CommandServiceReference.CommandServiceClient _cmdClient;

    public CommandServiceReference.CommandServiceClient CommandClient
    {
      get { return _cmdClient; }
      set { _cmdClient = value; }
    }

    ProductQueryServiceReference.ProductQueryServiceClient _prodQueryClient;
    public ProductQueryServiceReference.ProductQueryServiceClient ProductQueryClient
    {
      get{return _prodQueryClient;}
      set { _prodQueryClient = value; }
    }
    public ServiceClient Initialise()
    {
      try
      {
        _custQueryClient = new OrderProcessing.CustomerQueryServiceReference.CustomerQueryServiceClient();
        _custQueryClient.Open();

        _orderQueryClient = new OrderProcessing.OrderQueryServiceReference.OrderQueryServiceClient();
        _orderQueryClient.Open();

        _empQueryClient = new OrderProcessing.EmployeeQueryServiceReference.EmployeeQueryServiceClient();
        _empQueryClient.Open();

        _cmdClient = new OrderProcessing.CommandServiceReference.CommandServiceClient();
        _cmdClient.Open();

        _prodQueryClient = new OrderProcessing.ProductQueryServiceReference.ProductQueryServiceClient();
        _prodQueryClient.Open();

      }
      catch (Exception ex)
      {
        throw;
      }

      return this;
    }
  }
}
