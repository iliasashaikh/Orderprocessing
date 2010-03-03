using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

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

    SubscriptionServiceReference.SubscriptionServiceClient _subscriptionClient;

    public SubscriptionServiceReference.SubscriptionServiceClient SubscriptionClient
    {
      get { return _subscriptionClient; }
      set { _subscriptionClient = value; }
    }

    NotificationHandler _handler;

    public NotificationHandler ServiceNotificationHandler
    {
      get { return _handler; }
      set { _handler = value; }
    }

    public ServiceClient Initialise()
    {
      try
      {
        string contextId = Guid.NewGuid().ToString();

        _custQueryClient = new OrderProcessing.CustomerQueryServiceReference.CustomerQueryServiceClient();
        Common.Util.SetContextId(_custQueryClient.InnerChannel, contextId);
        _custQueryClient.Open();

        _orderQueryClient = new OrderProcessing.OrderQueryServiceReference.OrderQueryServiceClient();
        Common.Util.SetContextId(_orderQueryClient.InnerChannel, contextId);
        _orderQueryClient.Open();

        _empQueryClient = new OrderProcessing.EmployeeQueryServiceReference.EmployeeQueryServiceClient();
        Common.Util.SetContextId(_empQueryClient.InnerChannel, contextId);
        _empQueryClient.Open();

        _cmdClient = new OrderProcessing.CommandServiceReference.CommandServiceClient();
        Common.Util.SetContextId(_cmdClient.InnerChannel, contextId);
        _cmdClient.Open();

        _prodQueryClient = new OrderProcessing.ProductQueryServiceReference.ProductQueryServiceClient();
        Common.Util.SetContextId(_prodQueryClient.InnerChannel, contextId);
        _prodQueryClient.Open();

        _handler = new NotificationHandler();
        InstanceContext cntx = new InstanceContext(_handler);

        _subscriptionClient = new OrderProcessing.SubscriptionServiceReference.SubscriptionServiceClient(cntx);
        SubscriptionClient.Open();
        SubscriptionClient.Subscribe();

      }
      catch (Exception ex)
      {
        throw;
      }

      return this;
    }
  }
}
