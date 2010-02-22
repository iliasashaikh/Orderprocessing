using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OrderProcessingDomain;
using System.ServiceModel;
using System.Threading;

namespace OrderProcessing
{
  public partial class Form1 : Form
  {
    OrderProcessing.ServiceReference1.OrdersClient _ordRef;
    OrderProcessing.OrderStatusService.StatusClient _statusRef;

    ServiceReference1.IOrdersCallback _orderCallbackHandler;

    public Form1()
    {
      InitializeComponent();
      try
      {
        _orderCallbackHandler = new OrderCallbackHandler(this);
        _ordRef = new OrderProcessing.ServiceReference1.OrdersClient(new System.ServiceModel.InstanceContext(_orderCallbackHandler));
        _statusRef = new OrderProcessing.OrderStatusService.StatusClient();
        _ordRef.Subscribe();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
      }
    }

    internal void GetAllOrders()
    {
      Order[] orders=null;
      Thread th;
      th = new Thread(
        () =>
        {
          try
          {
            _statusRef = new OrderProcessing.OrderStatusService.StatusClient();
            orders = _statusRef.GetAllOrders();
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
          }
        }
      );
      th.Start();
      th.Join();
      dataGridView1.DataSource = orders;
    }

    private void button1_Click(object sender, EventArgs e)
    {

      try
      {
        //this.Cursor = Cursors.WaitCursor;
        //Order[] orders = _ordRef.GetAllOrders();
        //dataGridView1.DataSource = orders;
        GetAllOrders();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        Order order = dataGridView1.SelectedRows[0].DataBoundItem as Order;

        if (order != null)
          _ordRef.DeleteOrderAsync(order);
        
        
        //dataGridView1.DataSource = _ordRef.GetAllOrders();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnSubscribe_Click(object sender, EventArgs e)
    {
     
    }
  }

  [CallbackBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
  class OrderCallbackHandler : ServiceReference1.IOrdersCallback,IDisposable
  {
    Form1 _parent;

    public OrderCallbackHandler(Form1 parent)
    {
      _parent = parent;
    }

    public void OrderAdded(Order order)
    {
      MessageBox.Show(String.Format("Order {0} added - ",order.OrderId));
    }

    public void OrderUpdated(Order order)
    {
      throw new NotImplementedException();
    }

    public void OrderRemoved(Order order)
    {
      _parent.Invoke((Action)(()=>
      {
        _parent.toolStripStatusLabel_OrderStatus.Text = String.Format("Order {0} deleted ", order.OrderId);
        _parent.GetAllOrders();
      }));
    }


    #region IDisposable Members

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IOrdersCallback Members


    public IAsyncResult BeginOrderAdded(Order order, AsyncCallback callback, object asyncState)
    {
      throw new NotImplementedException();
    }

    public void EndOrderAdded(IAsyncResult result)
    {
      throw new NotImplementedException();
    }

    public IAsyncResult BeginOrderUpdated(Order order, AsyncCallback callback, object asyncState)
    {
      OrderRemoved(order);
      return null;
    }

    public void EndOrderUpdated(IAsyncResult result)
    {
      throw new NotImplementedException();
    }

    public IAsyncResult BeginOrderRemoved(Order order, AsyncCallback callback, object asyncState)
    {
      throw new NotImplementedException();
    }

    public void EndOrderRemoved(IAsyncResult result)
    {
      //throw new NotImplementedException();
    }

    #endregion
  }
}
