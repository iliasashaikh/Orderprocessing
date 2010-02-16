using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OrderProcessingDomain;

namespace OrderProcessing
{
  public partial class Form1 : Form
  {
    OrderProcessing.ServiceReference1.OrdersClient _ordRef;

    public Form1()
    {
      InitializeComponent();
      _ordRef = new OrderProcessing.ServiceReference1.OrdersClient("orderTcpBinding");
    }

    private void button1_Click(object sender, EventArgs e)
    {

      try
      {
        this.Cursor = Cursors.WaitCursor;
        Order[] orders = _ordRef.GetAllOrders();
        dataGridView1.DataSource = orders;
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
      Order order = dataGridView1.SelectedRows[0].DataBoundItem as Order;
      if (order != null)
        _ordRef.DeleteOrder(order);
      dataGridView1.DataSource = _ordRef.GetAllOrders();
    }
  }
}
