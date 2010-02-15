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
      ServiceHost host = new ServiceHost(typeof(OrderService.Orders));
      host.Open();
      Console.WriteLine("Any key to stop");
      Console.ReadKey();
    }
  }
}
