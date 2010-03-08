using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using OrderProcessingDomain;
using OrderProcessingDomain.Command;
using OrderService;
using System.ServiceModel;
using NHibernate;

namespace OrderProcessing.Tests
{
  public class NotificationHandler : SubscriptionServiceReference.ISubscriptionServiceCallback
  {
    #region ISubscriptionServiceCallback Members

    public void Notify(string message)
    {
      NotifyClient(message);
    }

    string NotifyClient(string message)
    {
      return message;
    }

    public IAsyncResult BeginNotify(string message, AsyncCallback callback, object asyncState)
    {
      throw new NotImplementedException();
    }

    public void EndNotify(IAsyncResult result)
    {
      throw new NotImplementedException();
    }

    #endregion
  }


  [TestFixture]
  public class CommandServiceTest
  {
    [Test]
    [Category("WCFTest")]
    public void Subscribe()
    {
      NotificationHandler handler = new NotificationHandler();
      InstanceContext cntx = new InstanceContext(handler);
      SubscriptionServiceReference.SubscriptionServiceClient proxy = new OrderProcessing.Tests.SubscriptionServiceReference.SubscriptionServiceClient(cntx);
      proxy.Subscribe();
    }

    [Test]
    public void TestCreateColumnInCustomerTable()
    {
      AddColumnCommand colCommand = new AddColumnCommand(typeof(Customer), "CustomColumn3", OrderProcessingDomain.Repositories.CustomColumnType.DateTime);
      colCommand.Execute();
    }

    [Test]
    public void TestAddOrder()
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

      Repositiory.Close(Common.Util.GetContextId());
    }

    [Test]
    public void TestDeleteOrderAndUndo()
    {
      OrderService.OrderService service = new OrderService.OrderService();
      long numOrders = service.GetOrderCount();
      var allOrders = service.GetAllOrders();
      Order order = allOrders.ElementAt(new Random().Next(0, (int)numOrders - 1));
      RemoveOrderCommand remCommand = new RemoveOrderCommand(order);
      CommandService commandService = new CommandService();
      commandService.ExecuteCommand(remCommand);
      commandService.UndoCommand(remCommand);
      long numOrdersAfter = service.GetOrderCount();
      Assert.That(numOrdersAfter, Is.EqualTo(numOrders));
      Repositiory.Close(Common.Util.GetContextId());
    }


    [Test]
    [Category("WCFTest")]
    public void TestDeleteOrderAndUndoUsingWCFAsync()
    {
      NotificationHandler handler = new NotificationHandler();
      InstanceContext cntx = new InstanceContext(handler);
      SubscriptionServiceReference.SubscriptionServiceClient proxy = new OrderProcessing.Tests.SubscriptionServiceReference.SubscriptionServiceClient(cntx);
      proxy.Subscribe();

      string contextId = Guid.NewGuid().ToString();
      CommanndServiceReference.CommandServiceClient commandClient = new OrderProcessing.Tests.CommanndServiceReference.CommandServiceClient();
      OrderQueryServiceReference.OrderQueryServiceClient service = new OrderProcessing.Tests.OrderQueryServiceReference.OrderQueryServiceClient();

      //Common.Util.SetContextId(commandClient.InnerChannel, contextId);
      AssignContextId(commandClient.InnerChannel, contextId);
      AssignContextId(service.InnerChannel, contextId);
      //Common.Util.SetContextId(service.InnerChannel, contextId);

      long numOrders = service.Count();
      var allOrders = service.All();
      Order order = allOrders.ElementAt(new Random().Next(0, (int)numOrders - 1));
      RemoveOrderCommand remCommand = new RemoveOrderCommand(order);
      //commandClient.BeginExecuteCommand(remCommand, ar => {}, null);
      commandClient.ExecuteCommand(remCommand);
      commandClient.UndoCommand(remCommand);
      long numOrdersAfter = service.Count();
      Assert.That(numOrdersAfter, Is.EqualTo(numOrders));
    }


    [Test]
    [Category("WCFTest")]
    public void TestDeleteOrderAndUndoUsingWCF()
    {
      NotificationHandler handler = new NotificationHandler();
      InstanceContext cntx = new InstanceContext(handler);
      SubscriptionServiceReference.SubscriptionServiceClient proxy = new OrderProcessing.Tests.SubscriptionServiceReference.SubscriptionServiceClient(cntx);
      proxy.Subscribe();

      string contextId = Guid.NewGuid().ToString();
      CommanndServiceReference.CommandServiceClient commandClient = new OrderProcessing.Tests.CommanndServiceReference.CommandServiceClient();
      OrderQueryServiceReference.OrderQueryServiceClient service = new OrderProcessing.Tests.OrderQueryServiceReference.OrderQueryServiceClient();
      
      //Common.Util.SetContextId(commandClient.InnerChannel, contextId);
      AssignContextId(commandClient.InnerChannel,contextId);
      AssignContextId(service.InnerChannel, contextId);
      //Common.Util.SetContextId(service.InnerChannel, contextId);

      long numOrders = service.Count();
      var allOrders = service.All();
      Order order = allOrders.ElementAt(new Random().Next(0, (int)numOrders - 1));
      RemoveOrderCommand remCommand = new RemoveOrderCommand(order);
      commandClient.ExecuteCommand(remCommand);
      commandClient.UndoCommand(remCommand);
      long numOrdersAfter = service.Count();
      Assert.That(numOrdersAfter, Is.EqualTo(numOrders));
    }

    [Test]
    public void TestDeleteCustomerAndUndo()
    {
      OrderService.QueryService.CustomerQueryService service = new OrderService.QueryService.CustomerQueryService();
      var customers = service.All();
      long count = service.Count();

      Customer customer = customers.ElementAt(new Random().Next(0, (int)count - 1));

      RemoveCustomerCommand command = new RemoveCustomerCommand(customer);
      CommandService commandService = new CommandService();
      commandService.ExecuteCommand(command);
      commandService.Undo();

      long countAfter = service.Count();
      Assert.That(count, Is.EqualTo(countAfter));
      Repositiory.Close(Common.Util.GetContextId());
    }


    [Test]
    [Category("WCFTest")]
    public void TestDeleteCustomerAndUndoUsingWCF()
    {
      string contextId = Guid.NewGuid().ToString();
      CommanndServiceReference.CommandServiceClient cmdClient = new OrderProcessing.Tests.CommanndServiceReference.CommandServiceClient();
      CustomerQueryServiceReference.CustomerQueryServiceClient custQueryClient = new OrderProcessing.Tests.CustomerQueryServiceReference.CustomerQueryServiceClient();
      AssignContextId(custQueryClient.InnerChannel,contextId);
      AssignContextId(cmdClient.InnerChannel,contextId);
      var customers = custQueryClient.All();
      long count = custQueryClient.Count();
      Customer customer = customers.ElementAt(new Random().Next(0, (int)count - 1));
      //Customer customer = customers.Where(x => x.CustomerId == "YLHWC").First();

      RemoveCustomerCommand command = new RemoveCustomerCommand(customer);
      cmdClient.ExecuteCommand(command);
      cmdClient.Undo();

      long countAfter = custQueryClient.Count();
      Assert.That(count, Is.EqualTo(countAfter));
    }

    [Test]
    [Category("WCFTest")]
    public void TestAddOrderUsingService()
    {
      Order order1 = new Order();
      Order order2 = new Order();
      Order order3 = new Order();


      AddOrderCommand addCommand1 = new AddOrderCommand(order1);
      AddOrderCommand addCommand2 = new AddOrderCommand(order2);
      AddOrderCommand addCommand3 = new AddOrderCommand(order3);

      CommanndServiceReference.CommandServiceClient service = new OrderProcessing.Tests.CommanndServiceReference.CommandServiceClient();
      AssignContextId(service.InnerChannel);
      addCommand1 = (AddOrderCommand)service.ExecuteCommand(addCommand1);
      addCommand2 = (AddOrderCommand)service.ExecuteCommand(addCommand2);
      addCommand3 = (AddOrderCommand)service.ExecuteCommand(addCommand3);

      ICommand command = (ICommand)service.Undo();
      Order deletedOrder = command.CommandParams[0] as Order;
      Assert.That(((Order)addCommand3.CommandParams[0]).OrderId, Is.EqualTo(deletedOrder.OrderId));
    }

    void AssignContextId(IClientChannel innerChannel)
    {
      string contextId = Guid.NewGuid().ToString();
      Common.Util.SetContextId(innerChannel,contextId);
    }

    void AssignContextId(IClientChannel innerChannel, string contextId)
    {
      Common.Util.SetContextId(innerChannel, contextId);
    }
  }
}
