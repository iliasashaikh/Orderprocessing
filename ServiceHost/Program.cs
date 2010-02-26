using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OrderProcessingDomain;

namespace ConsoleServiceHost
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        ServiceHost hostOrders = new ServiceHost(typeof(OrderService.OrderService));
        ServiceHost hostStatus = new ServiceHost(typeof(OrderProcessingDomain.Status));
        ServiceHost hostCommand = new ServiceHost(typeof(OrderService.CommandService));

        ServiceHost hostQueryCustomer = new ServiceHost(typeof(OrderService.QueryService.CustomerQueryService));
        ServiceHost hostQueryEmployee = new ServiceHost(typeof(OrderService.QueryService.EmployeeQueryService));
        ServiceHost hostQueryOrder = new ServiceHost(typeof(OrderService.QueryService.OrderQueryService));

        hostCommand.Open();
        //hostOrders.Open();
        //hostStatus.Open();

        hostQueryCustomer.Open();
        hostQueryEmployee.Open();
        hostQueryOrder.Open();

        Console.WriteLine("Any key to stop");
        Console.ReadLine();
      }
      catch (Exception ex)
      {
        ShowError(ex);
        Console.ReadKey();
      }
    }

    static void ShowError(Exception ex)
    {
      Console.WriteLine(ex.Message);
      Console.WriteLine(ex.StackTrace);
      if (ex.InnerException != null)
        ShowError(ex.InnerException);
    }
  }
}
