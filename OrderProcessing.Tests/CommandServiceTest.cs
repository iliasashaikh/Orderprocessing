using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using OrderProcessingDomain;
using OrderProcessingDomain.Command;
using OrderService;
namespace OrderProcessing.Tests
{
  [TestFixture]
  class CommandServiceTest
  {
    [Test]
    void TestAddOrder()
    {
      Order order1 = new Order();
      Order order2 = new Order();
      Order order3 = new Order();

      AddOrderCommand addCommand1 = new AddOrderCommand(order1);
      AddOrderCommand addCommand2 = new AddOrderCommand(order2);
      AddOrderCommand addCommand3 = new AddOrderCommand(order3);

      CommandService service = new CommandService();

      service.ExecuteCommand(addCommand1);
      service.ExecuteCommand(addCommand2);
      service.ExecuteCommand(addCommand3);

      ICommand command = service.Undo();
      Order deletedOrder = command.CommandParams[0] as Order;
      Assert.That(order3.OrderId,Is.EqualTo(deletedOrder.OrderId));
    }

    void TestDeleteOrderAndUndo()
    {
      OrderService.OrderService service = new OrderService.OrderService();
      int numOrders = service.GetOrderCount();
      var allOrders = service.GetAllOrders();
      Order order = allOrders.ElementAt(new Random().Next(0, numOrders - 1));
      //Order order = allOrders.Where(x => x.OrderId == 10680).First();

      RemoveOrderCommand remCommand = new RemoveOrderCommand(order);
      CommandService commandService = new CommandService();
      commandService.ExecuteCommand(remCommand);
      commandService.Undo();
      int numOrdersAfter = service.GetOrderCount();
      Assert.That(numOrdersAfter, Is.EqualTo(numOrders));
    }


    [Test]
    [Category("WCFTest")]
    void TestAddOrderUsingService()
    {
      Order order1 = new Order();
      Order order2 = new Order();
      Order order3 = new Order();


      AddOrderCommand addCommand1 = new AddOrderCommand(order1);
      AddOrderCommand addCommand2 = new AddOrderCommand(order2);
      AddOrderCommand addCommand3 = new AddOrderCommand(order3);

      CommanndServiceReference.CommandServiceClient service = new OrderProcessing.Tests.CommanndServiceReference.CommandServiceClient();

      addCommand1 = (AddOrderCommand)service.ExecuteCommand(addCommand1);
      addCommand2 = (AddOrderCommand)service.ExecuteCommand(addCommand2);
      addCommand3 = (AddOrderCommand)service.ExecuteCommand(addCommand3);

      ICommand command = (ICommand)service.Undo();
      Order deletedOrder = command.CommandParams[0] as Order;
      Assert.That(((Order)addCommand3.CommandParams[0]).OrderId, Is.EqualTo(deletedOrder.OrderId));
    }

  }
}
