namespace OrderProcessing
{
  partial class OrderProcessingDemo
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Orders");
      System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Customers");
      System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Employees");
      System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Products");
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.button_Connect = new System.Windows.Forms.Button();
      this.label_Connect = new System.Windows.Forms.Label();
      this.menuStrip_MainMenu = new System.Windows.Forms.MenuStrip();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.treeView_Entities = new System.Windows.Forms.TreeView();
      this.label_Count = new System.Windows.Forms.Label();
      this.textBox_Order = new System.Windows.Forms.TextBox();
      this.dataGridView_Content = new System.Windows.Forms.DataGridView();
      this.button_Last = new System.Windows.Forms.Button();
      this.button_Next = new System.Windows.Forms.Button();
      this.button_Previous = new System.Windows.Forms.Button();
      this.button_First = new System.Windows.Forms.Button();
      this.splitContainer4 = new System.Windows.Forms.SplitContainer();
      this.statusStrip_Messages = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel_Messages = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel_ServiceStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.menuStrip_MainMenu.SuspendLayout();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Content)).BeginInit();
      this.splitContainer4.Panel2.SuspendLayout();
      this.splitContainer4.SuspendLayout();
      this.statusStrip_Messages.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
      this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
      this.splitContainer1.Size = new System.Drawing.Size(1019, 674);
      this.splitContainer1.SplitterDistance = 435;
      this.splitContainer1.TabIndex = 0;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.button_Connect);
      this.splitContainer2.Panel1.Controls.Add(this.label_Connect);
      this.splitContainer2.Panel1.Controls.Add(this.menuStrip_MainMenu);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
      this.splitContainer2.Size = new System.Drawing.Size(1017, 433);
      this.splitContainer2.SplitterDistance = 25;
      this.splitContainer2.TabIndex = 0;
      // 
      // button_Connect
      // 
      this.button_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_Connect.Location = new System.Drawing.Point(949, 2);
      this.button_Connect.Name = "button_Connect";
      this.button_Connect.Size = new System.Drawing.Size(65, 21);
      this.button_Connect.TabIndex = 2;
      this.button_Connect.Text = "Connect";
      this.button_Connect.UseVisualStyleBackColor = true;
      this.button_Connect.Visible = false;
      this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
      // 
      // label_Connect
      // 
      this.label_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label_Connect.AutoSize = true;
      this.label_Connect.Location = new System.Drawing.Point(760, 6);
      this.label_Connect.Name = "label_Connect";
      this.label_Connect.Size = new System.Drawing.Size(0, 13);
      this.label_Connect.TabIndex = 1;
      // 
      // menuStrip_MainMenu
      // 
      this.menuStrip_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem});
      this.menuStrip_MainMenu.Location = new System.Drawing.Point(0, 0);
      this.menuStrip_MainMenu.Name = "menuStrip_MainMenu";
      this.menuStrip_MainMenu.Size = new System.Drawing.Size(1017, 24);
      this.menuStrip_MainMenu.TabIndex = 0;
      this.menuStrip_MainMenu.Text = "menuStrip1";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.newToolStripMenuItem.Text = "New";
      // 
      // reloadToolStripMenuItem
      // 
      this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
      this.reloadToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.reloadToolStripMenuItem.Text = "Reload";
      // 
      // updateToolStripMenuItem
      // 
      this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
      this.updateToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.updateToolStripMenuItem.Text = "Update";
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // undoToolStripMenuItem
      // 
      this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
      this.undoToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
      this.undoToolStripMenuItem.Text = "Undo";
      this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.treeView_Entities);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.label_Count);
      this.splitContainer3.Panel2.Controls.Add(this.textBox_Order);
      this.splitContainer3.Panel2.Controls.Add(this.dataGridView_Content);
      this.splitContainer3.Panel2.Controls.Add(this.button_Last);
      this.splitContainer3.Panel2.Controls.Add(this.button_Next);
      this.splitContainer3.Panel2.Controls.Add(this.button_Previous);
      this.splitContainer3.Panel2.Controls.Add(this.button_First);
      this.splitContainer3.Size = new System.Drawing.Size(1017, 404);
      this.splitContainer3.SplitterDistance = 208;
      this.splitContainer3.TabIndex = 0;
      // 
      // treeView_Entities
      // 
      this.treeView_Entities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.treeView_Entities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.treeView_Entities.Location = new System.Drawing.Point(3, 3);
      this.treeView_Entities.Name = "treeView_Entities";
      treeNode5.Name = "Node_Orders";
      treeNode5.Text = "Orders";
      treeNode6.Name = "Node_Customers";
      treeNode6.Text = "Customers";
      treeNode7.Name = "Node_Employees";
      treeNode7.Text = "Employees";
      treeNode8.Name = "Node_Products";
      treeNode8.Text = "Products";
      this.treeView_Entities.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
      this.treeView_Entities.ShowLines = false;
      this.treeView_Entities.Size = new System.Drawing.Size(202, 369);
      this.treeView_Entities.TabIndex = 0;
      this.treeView_Entities.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Entities_AfterSelect);
      // 
      // label_Count
      // 
      this.label_Count.AutoSize = true;
      this.label_Count.Location = new System.Drawing.Point(185, 6);
      this.label_Count.Name = "label_Count";
      this.label_Count.Size = new System.Drawing.Size(13, 13);
      this.label_Count.TabIndex = 1;
      this.label_Count.Text = "0";
      // 
      // textBox_Order
      // 
      this.textBox_Order.Location = new System.Drawing.Point(3, 3);
      this.textBox_Order.Name = "textBox_Order";
      this.textBox_Order.Size = new System.Drawing.Size(154, 20);
      this.textBox_Order.TabIndex = 5;
      this.textBox_Order.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // dataGridView_Content
      // 
      this.dataGridView_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView_Content.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView_Content.Location = new System.Drawing.Point(0, 29);
      this.dataGridView_Content.Name = "dataGridView_Content";
      this.dataGridView_Content.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView_Content.Size = new System.Drawing.Size(802, 343);
      this.dataGridView_Content.TabIndex = 4;
      // 
      // button_Last
      // 
      this.button_Last.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button_Last.AutoEllipsis = true;
      this.button_Last.Location = new System.Drawing.Point(774, 376);
      this.button_Last.Name = "button_Last";
      this.button_Last.Size = new System.Drawing.Size(28, 22);
      this.button_Last.TabIndex = 3;
      this.button_Last.Text = ">>";
      this.button_Last.UseVisualStyleBackColor = true;
      // 
      // button_Next
      // 
      this.button_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button_Next.Location = new System.Drawing.Point(740, 376);
      this.button_Next.Name = "button_Next";
      this.button_Next.Size = new System.Drawing.Size(28, 22);
      this.button_Next.TabIndex = 2;
      this.button_Next.Text = ">";
      this.button_Next.UseVisualStyleBackColor = true;
      // 
      // button_Previous
      // 
      this.button_Previous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button_Previous.Location = new System.Drawing.Point(37, 376);
      this.button_Previous.Name = "button_Previous";
      this.button_Previous.Size = new System.Drawing.Size(28, 22);
      this.button_Previous.TabIndex = 1;
      this.button_Previous.Text = "<";
      this.button_Previous.UseVisualStyleBackColor = true;
      // 
      // button_First
      // 
      this.button_First.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button_First.Location = new System.Drawing.Point(3, 376);
      this.button_First.Name = "button_First";
      this.button_First.Size = new System.Drawing.Size(28, 22);
      this.button_First.TabIndex = 0;
      this.button_First.Text = "<<";
      this.button_First.UseVisualStyleBackColor = true;
      // 
      // splitContainer4
      // 
      this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer4.Location = new System.Drawing.Point(0, 0);
      this.splitContainer4.Name = "splitContainer4";
      this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer4.Panel2
      // 
      this.splitContainer4.Panel2.Controls.Add(this.statusStrip_Messages);
      this.splitContainer4.Size = new System.Drawing.Size(1017, 233);
      this.splitContainer4.SplitterDistance = 175;
      this.splitContainer4.TabIndex = 0;
      // 
      // statusStrip_Messages
      // 
      this.statusStrip_Messages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Messages,
            this.toolStripStatusLabel_ServiceStatus});
      this.statusStrip_Messages.Location = new System.Drawing.Point(0, 32);
      this.statusStrip_Messages.Name = "statusStrip_Messages";
      this.statusStrip_Messages.Size = new System.Drawing.Size(1017, 22);
      this.statusStrip_Messages.TabIndex = 0;
      this.statusStrip_Messages.Text = "statusStrip1";
      // 
      // toolStripStatusLabel_Messages
      // 
      this.toolStripStatusLabel_Messages.Name = "toolStripStatusLabel_Messages";
      this.toolStripStatusLabel_Messages.Size = new System.Drawing.Size(0, 17);
      // 
      // toolStripStatusLabel_ServiceStatus
      // 
      this.toolStripStatusLabel_ServiceStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                  | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                  | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
      this.toolStripStatusLabel_ServiceStatus.Name = "toolStripStatusLabel_ServiceStatus";
      this.toolStripStatusLabel_ServiceStatus.Size = new System.Drawing.Size(4, 17);
      this.toolStripStatusLabel_ServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // OrderProcessingDemo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1019, 674);
      this.Controls.Add(this.splitContainer1);
      this.Name = "OrderProcessingDemo";
      this.Text = "Order Processing Demo";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.menuStrip_MainMenu.ResumeLayout(false);
      this.menuStrip_MainMenu.PerformLayout();
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      this.splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Content)).EndInit();
      this.splitContainer4.Panel2.ResumeLayout(false);
      this.splitContainer4.Panel2.PerformLayout();
      this.splitContainer4.ResumeLayout(false);
      this.statusStrip_Messages.ResumeLayout(false);
      this.statusStrip_Messages.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.MenuStrip menuStrip_MainMenu;
    private System.Windows.Forms.DataGridView dataGridView_Content;
    private System.Windows.Forms.Button button_Last;
    private System.Windows.Forms.Button button_Next;
    private System.Windows.Forms.Button button_Previous;
    private System.Windows.Forms.Button button_First;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    private System.Windows.Forms.TreeView treeView_Entities;
    private System.Windows.Forms.SplitContainer splitContainer4;
    private System.Windows.Forms.StatusStrip statusStrip_Messages;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Messages;
    private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ServiceStatus;
    private System.Windows.Forms.TextBox textBox_Order;
    private System.Windows.Forms.Label label_Count;
    private System.Windows.Forms.Label label_Connect;
    private System.Windows.Forms.Button button_Connect;
  }
}