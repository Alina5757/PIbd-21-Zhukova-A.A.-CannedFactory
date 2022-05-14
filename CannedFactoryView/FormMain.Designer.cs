﻿
namespace CannedFactoryView
{
    partial class FormMain
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRefact = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemComponents = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCanneds = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClients = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImplementer = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentCannedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemWork = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMessage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(816, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(861, 83);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(150, 31);
            this.buttonCreateOrder.TabIndex = 1;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(861, 151);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(150, 31);
            this.buttonIssuedOrder.TabIndex = 4;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRefact
            // 
            this.buttonRefact.Location = new System.Drawing.Point(861, 218);
            this.buttonRefact.Name = "buttonRefact";
            this.buttonRefact.Size = new System.Drawing.Size(150, 31);
            this.buttonRefact.TabIndex = 5;
            this.buttonRefact.Text = "Обновить список";
            this.buttonRefact.UseVisualStyleBackColor = true;
            this.buttonRefact.Click += new System.EventHandler(this.buttonRefact_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.отчетыToolStripMenuItem,
            this.ToolStripMenuItemWork});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemComponents,
            this.ToolStripMenuItemCanneds,
            this.ToolStripMenuItemClients,
            this.ToolStripMenuItemImplementer,
            this.ToolStripMenuItemMessage});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItem1.Text = "Справочники";
            // 
            // ToolStripMenuItemComponents
            // 
            this.ToolStripMenuItemComponents.Name = "ToolStripMenuItemComponents";
            this.ToolStripMenuItemComponents.Size = new System.Drawing.Size(197, 22);
            this.ToolStripMenuItemComponents.Text = "Список компонентов";
            this.ToolStripMenuItemComponents.Click += new System.EventHandler(this.ToolStripMenuItemComponents_Click);
            // 
            // ToolStripMenuItemCanneds
            // 
            this.ToolStripMenuItemCanneds.Name = "ToolStripMenuItemCanneds";
            this.ToolStripMenuItemCanneds.Size = new System.Drawing.Size(197, 22);
            this.ToolStripMenuItemCanneds.Text = "Список изделий";
            this.ToolStripMenuItemCanneds.Click += new System.EventHandler(this.ToolStripMenuItemCanneds_Click);
            // 
            // ToolStripMenuItemClients
            // 
            this.ToolStripMenuItemClients.Name = "ToolStripMenuItemClients";
            this.ToolStripMenuItemClients.Size = new System.Drawing.Size(197, 22);
            this.ToolStripMenuItemClients.Text = "Список клиентов";
            this.ToolStripMenuItemClients.Click += new System.EventHandler(this.ToolStripMenuItemClients_Click);
            // 
            // ToolStripMenuItemImplementer
            // 
            this.ToolStripMenuItemImplementer.Name = "ToolStripMenuItemImplementer";
            this.ToolStripMenuItemImplementer.Size = new System.Drawing.Size(197, 22);
            this.ToolStripMenuItemImplementer.Text = "Список исполнителей";
            this.ToolStripMenuItemImplementer.Click += new System.EventHandler(this.ToolStripMenuItemImplementer_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComponentsToolStripMenuItem,
            this.ComponentCannedsToolStripMenuItem,
            this.OrdersToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // ComponentsToolStripMenuItem
            // 
            this.ComponentsToolStripMenuItem.Name = "ComponentsToolStripMenuItem";
            this.ComponentsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ComponentsToolStripMenuItem.Text = "Список консервов";
            this.ComponentsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // ComponentCannedsToolStripMenuItem
            // 
            this.ComponentCannedsToolStripMenuItem.Name = "ComponentCannedsToolStripMenuItem";
            this.ComponentCannedsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ComponentCannedsToolStripMenuItem.Text = "Компоненты в изделиях";
            this.ComponentCannedsToolStripMenuItem.Click += new System.EventHandler(this.ComponentCannedsToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.OrdersToolStripMenuItem.Text = "Список заказов";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemWork
            // 
            this.ToolStripMenuItemWork.Name = "ToolStripMenuItemWork";
            this.ToolStripMenuItemWork.Size = new System.Drawing.Size(92, 20);
            this.ToolStripMenuItemWork.Text = "Запуск работ";
            this.ToolStripMenuItemWork.Click += new System.EventHandler(this.ToolStripMenuItemWork_Click);
            // 
            // ToolStripMenuItemMessage
            // 
            this.ToolStripMenuItemMessage.Name = "ToolStripMenuItemMessage";
            this.ToolStripMenuItemMessage.Size = new System.Drawing.Size(197, 22);
            this.ToolStripMenuItemMessage.Text = "Список писем";
            this.ToolStripMenuItemMessage.Click += new System.EventHandler(this.ToolStripMenuItemMessage_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 405);
            this.Controls.Add(this.buttonRefact);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Рыбный завод";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonIssuedOrder;
        private System.Windows.Forms.Button buttonRefact;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemComponents;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCanneds;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentCannedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClients;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImplementer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemWork;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMessage;
    }
}