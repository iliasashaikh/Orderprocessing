using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace ConsoleServiceHost
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        ServiceHost hostOrders = new ServiceHost(typeof(OrderService.Orders));
        ServiceHost hostStatus = new ServiceHost(typeof(OrderService.Status));
        hostOrders.Open();
        hostStatus.Open();
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
