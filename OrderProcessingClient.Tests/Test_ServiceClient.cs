using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using OrderProcessing.Classes;

namespace OrderProcessingClient.Tests
{
  [TestFixture]
  public class Test_ServiceClient
  {
    [Test]
    void Test_Initialise()
    {
      ServiceClient client = new ServiceClient().Initialise();
    }

    void Test_GetAllCustomers()
    {
      ServiceClient client = new ServiceClient().Initialise();
      var results = new Query().GetAllCustomers(client);
      Assert.That(results, Is.Not.Null);
    }

    void Test_GetAllOrders()
    {
      ServiceClient client = new ServiceClient().Initialise();
      var results = new Query().GetAllOrders(client);
      Assert.That(results, Is.Not.Null);
    }

    void Test_GetAllEmployees()
    {
      ServiceClient client = new ServiceClient().Initialise();
      var results = new Query().GetAllEmployees(client);
      Assert.That(results, Is.Not.Null);
    }
  }
}
