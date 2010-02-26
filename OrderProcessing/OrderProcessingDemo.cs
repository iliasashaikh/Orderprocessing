using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OrderProcessingDomain;
using OrderProcessingDomain.Command;

namespace OrderProcessing
{
  public partial class OrderProcessingDemo : Form
  {
    Classes.ServiceClient serviceClient;
    Classes.Query query;

    public OrderProcessingDemo()
    {
      InitializeComponent();
      serviceClient = new OrderProcessing.Classes.ServiceClient().Initialise();
      query = new OrderProcessing.Classes.Query();
    }

    private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    private void treeView_Entities_AfterSelect(object sender, TreeViewEventArgs e)
    {
      switch (e.Node.Name)
      {
        case "Node_Orders":
          dataGridView_Content.DataSource = query.GetAllOrders(serviceClient);
          break;
        case "Node_Customers":
          dataGridView_Content.DataSource = query.GetAllCustomers(serviceClient);
          break;
        case "Node_Employees":
          dataGridView_Content.DataSource = query.GetAllEmployees(serviceClient);
          break;
        case "Node_Products":
          break;
      }

    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Order order = dataGridView_Content.SelectedRows[0].DataBoundItem as Order;
      if (order != null)
      {
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      Order[] orders = dataGridView_Content.DataSource as Order[];
      int orderId ;
      if (Int32.TryParse(textBox_Order.Text, out orderId) && orders != null)
      {
      }
    }
  }
}
