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
    Classes.ServiceClient _serviceClient;
    Classes.Query _query;
    TreeNode _selectedNode;
    bool _connected;

    public OrderProcessingDemo()
    {
      InitializeComponent();
      ConnectToServer();
      _query = new OrderProcessing.Classes.Query();
    }

    private void ConnectToServer()
    {
      try
      {
        _serviceClient = new OrderProcessing.Classes.ServiceClient().Initialise();
        _serviceClient.ServiceNotificationHandler.NotifyClient += (message) => toolStripStatusLabel_Messages.Text = message;

        _connected = true;
      }
      catch (Exception ex)
      {
        _connected = false;
      }
      DisplayConnectionStatus();
    }

    void DisplayConnectionStatus()
    {
      if (_connected)
      {
        label_Connect.Text = "Connected";
        button_Connect.Visible = false;
      }
      else
      {
        label_Connect.Text = "Not Connected";
        button_Connect.Visible = true;
      }
    }

    private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    Order[] _allOrders;
    Customer[] _allCustomers;
    Employee[] _allEmployees;

    private void treeView_Entities_AfterSelect(object sender, TreeViewEventArgs e)
    {
      _selectedNode = e.Node;
      ShowDataInGrid(false, "");
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Order order = dataGridView_Content.SelectedRows[0].DataBoundItem as Order;
      if (order != null)
      {
        DeleteOrder(order);
        return;
      }

      Customer customer = dataGridView_Content.SelectedRows[0].DataBoundItem as Customer;
      if (customer != null)
      {
        DeleteCustomer(customer);
        return;
      }

      Employee employee = dataGridView_Content.SelectedRows[0].DataBoundItem as Employee;
      if (employee != null)
      {
        DeleteEmployee(employee);
        return;
      }
    }

    private void DeleteEmployee(Employee employee)
    {
      throw new NotImplementedException();
    }


    Stack<ICommand> _commandStack = new Stack<ICommand>();

    private void DeleteCustomer(Customer customer)
    {
      ICommand removeCommand = new RemoveCustomerCommand(customer);
      RunCommand(removeCommand);
      ShowDataInGrid(false, "");
    }

    void RunCommand(ICommand command)
    {
      _serviceClient.CommandClient.ExecuteCommand(command);
      _commandStack.Push(command);
      ToolStripMenuItem undoCommandMenuItem = new ToolStripMenuItem(command.ToString());
      undoToolStripMenuItem.DropDownItems.Add(undoCommandMenuItem);

      //undoToolStripMenuItem.Click += (s, e) =>
      //  {
      //    UndoCommand();
      //    undoToolStripMenuItem.DropDownItems.RemoveAt(undoToolStripMenuItem.DropDownItems.Count-1);
      //  };
    }

    private void DeleteOrder(Order order)
    {
      ICommand command = new RemoveOrderCommand(order);
      RunCommand(command);
      ShowDataInGrid(false, "");
    }

    void ShowDataInGrid(bool filtered, string id)
    {
      Array toDisplay = null;

      if (String.IsNullOrEmpty(id))
        filtered = false;

      switch ( _selectedNode.Name)
      {
        case "Node_Orders":
          if (filtered)
          {
            var orders = dataGridView_Content.DataSource as Order[];
            var filteredList = orders.Where(o => o.OrderId.Value.ToString().Contains(id));
            toDisplay = filteredList.ToArray<Order>();
          }
          else
          {
            var orders = _query.GetAllOrders(_serviceClient);
            toDisplay = orders;
          }
          break;

        case "Node_Customers":
          if (filtered)
          {
            var customers = dataGridView_Content.DataSource as Customer[];
            var filteredList = customers.Where(c => c.CustomerId.Contains(id));
            toDisplay = filteredList.ToArray<Customer>();
          }
          else
          {
            var customers = _query.GetAllCustomers(_serviceClient);
            toDisplay = customers;
          }
          break;

        case "Node_Employees":
          if (filtered)
          {
            var employees = dataGridView_Content.DataSource as Employee[];
            var filteredList = employees.Where(e => e.EmployeeId.Value.ToString().Contains(id));
            toDisplay = filteredList.ToArray<Employee>();
          }
          else
          {
            var employees = _query.GetAllEmployees(_serviceClient);
            toDisplay = employees;
          }
          break;

        case "Node_Products":
          if (filtered)
          {
            var products = dataGridView_Content.DataSource as Product[];
            var filteredList = products.Where(p => p.ProductId.ToString().Contains(id));
            toDisplay = filteredList.ToArray<Product>();
          }
          else
          {
            var products = _query.GetAllProducts(_serviceClient);
            toDisplay = products;
          }
          break;
      }

      if (toDisplay != null)
      {
        dataGridView_Content.DataSource = toDisplay;
        label_Count.Text = toDisplay.Length.ToString();
      }
      else
      {
        dataGridView_Content.DataSource = null;
        label_Count.Text = "0";
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      ShowDataInGrid(true, textBox_Order.Text);
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (UndoCommand())
        undoToolStripMenuItem.DropDownItems.RemoveAt(undoToolStripMenuItem.DropDownItems.Count-1);
    }

    private bool UndoCommand()
    {
      if (_commandStack.Count == 0)
        return false;

      ICommand command = _commandStack.Pop();
      _serviceClient.CommandClient.Undo();
      ShowDataInGrid(false, "");
      return true;
    }


    private ICommand GetLastExecutedCommand()
    { 
      return _commandStack.Pop();
    }

    private void button_Connect_Click(object sender, EventArgs e)
    {
      ConnectToServer();
    }

    private void OrderProcessingDemo_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        _serviceClient.SubscriptionClient.UnSubscribe();
      }
      catch (Exception ex)
      {
      }
    }

    private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ShowDataInGrid(false, "");
    }


  }
}
