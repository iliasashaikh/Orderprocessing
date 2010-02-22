namespace OrderProcessing
{
  partial class Form1
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
      this.button1 = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnSubscribe = new System.Windows.Forms.Button();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel_OrderStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.btnGetAllCustomers = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(3, 339);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(79, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Show All";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(0, 12);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(740, 321);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDelete.Location = new System.Drawing.Point(107, 339);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(123, 23);
      this.btnDelete.TabIndex = 2;
      this.btnDelete.Text = "Delete Selected";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnSubscribe
      // 
      this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSubscribe.Location = new System.Drawing.Point(253, 339);
      this.btnSubscribe.Name = "btnSubscribe";
      this.btnSubscribe.Size = new System.Drawing.Size(81, 23);
      this.btnSubscribe.TabIndex = 3;
      this.btnSubscribe.Text = "Subscribe";
      this.btnSubscribe.UseVisualStyleBackColor = true;
      this.btnSubscribe.Visible = false;
      this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_OrderStatus});
      this.statusStrip1.Location = new System.Drawing.Point(0, 365);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(739, 22);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel_OrderStatus
      // 
      this.toolStripStatusLabel_OrderStatus.Name = "toolStripStatusLabel_OrderStatus";
      this.toolStripStatusLabel_OrderStatus.Size = new System.Drawing.Size(0, 17);
      // 
      // btnGetAllCustomers
      // 
      this.btnGetAllCustomers.Location = new System.Drawing.Point(353, 339);
      this.btnGetAllCustomers.Name = "btnGetAllCustomers";
      this.btnGetAllCustomers.Size = new System.Drawing.Size(116, 23);
      this.btnGetAllCustomers.TabIndex = 5;
      this.btnGetAllCustomers.Text = "All Customers";
      this.btnGetAllCustomers.UseVisualStyleBackColor = true;
      this.btnGetAllCustomers.Click += new System.EventHandler(this.btnGetAllCustomers_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(739, 387);
      this.Controls.Add(this.btnGetAllCustomers);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.btnSubscribe);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnSubscribe;
    private System.Windows.Forms.StatusStrip statusStrip1;
    protected internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_OrderStatus;
    private System.Windows.Forms.Button btnGetAllCustomers;
  }
}

