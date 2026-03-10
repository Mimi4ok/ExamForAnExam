using System.Windows.Forms;
using System;

namespace ProductClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtIP;
        private TextBox txtPort;
        private TextBox txtProducts;
        private Button btnConnect;
        private Button btnSend;
        private ListBox lstResponse;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstResponse = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(123, 10);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 22);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(123, 35);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(50, 22);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "8888";
            // 
            // txtProducts
            // 
            this.txtProducts.Location = new System.Drawing.Point(10, 70);
            this.txtProducts.Multiline = true;
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(156, 60);
            this.txtProducts.TabIndex = 3;
            this.txtProducts.Text = "Молоко, Хліб, Масло";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(356, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(116, 25);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Доєднатися";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(380, 70);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 60);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "запитати";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstResponse
            // 
            this.lstResponse.FormattingEnabled = true;
            this.lstResponse.ItemHeight = 16;
            this.lstResponse.Location = new System.Drawing.Point(10, 140);
            this.lstResponse.Name = "lstResponse";
            this.lstResponse.Size = new System.Drawing.Size(460, 212);
            this.lstResponse.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 370);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(136, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Стоїть не рухається";
            // 
            // lblIP
            // 
            this.lblIP.Location = new System.Drawing.Point(0, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(100, 23);
            this.lblIP.TabIndex = 7;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(0, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(100, 23);
            this.lblPort.TabIndex = 8;
            // 
            // lblProd
            // 
            this.lblProd.Location = new System.Drawing.Point(0, 0);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(100, 23);
            this.lblProd.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 10;
            this.label1.Tag = "";
            this.label1.Text = "Айпі серверу";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 11;
            this.label2.Tag = "";
            this.label2.Text = "Порт серверу";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lstResponse);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtProducts);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblProd);
            this.Name = "Form1";
            this.Text = "Клієнт товарів";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblIP;
        private Label lblPort;
        private Label lblProd;
        private Label label1;
        private Label label2;
    }
}