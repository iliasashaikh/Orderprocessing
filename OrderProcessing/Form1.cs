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
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      OrderProcessing.ServiceReference1.OrdersClient ord = new OrderProcessing.ServiceReference1.OrdersClient();
      OrderProcessing.ServiceReference1.Order[] orders = ord.GetAllOrders();
      dataGridView1.DataSource = orders;
    }
  }
}
