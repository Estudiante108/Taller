namespace Taller_Caja
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button3 = new Button();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            Numeroplaca = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            productos = new ComboBox();
            label5 = new Label();
            boxcantidad = new TextBox();
            txtcantidad = new TextBox();
            button1 = new Button();
            button2 = new Button();
            mecanicos = new ComboBox();
            label6 = new Label();
            panel1 = new Panel();
            label7 = new Label();
            menuStrip1 = new MenuStrip();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            registrarClienteToolStripMenuItem = new ToolStripMenuItem();
            registrarVehiculoToolStripMenuItem = new ToolStripMenuItem();
            registrarProductoToolStripMenuItem = new ToolStripMenuItem();
            salirDeCuentaToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // reportViewer1
            // 
            resources.ApplyResources(reportViewer1, "reportViewer1");
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column6, Column2, Column3, Column5, Column4 });
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            resources.ApplyResources(Column1, "Column1");
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column6
            // 
            resources.ApplyResources(Column6, "Column6");
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column2
            // 
            resources.ApplyResources(Column2, "Column2");
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            resources.ApplyResources(Column3, "Column3");
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column5
            // 
            resources.ApplyResources(Column5, "Column5");
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            resources.ApplyResources(Column4, "Column4");
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // Numeroplaca
            // 
            Numeroplaca.FormattingEnabled = true;
            Numeroplaca.Items.AddRange(new object[] { resources.GetString("Numeroplaca.Items"), resources.GetString("Numeroplaca.Items1"), resources.GetString("Numeroplaca.Items2") });
            resources.ApplyResources(Numeroplaca, "Numeroplaca");
            Numeroplaca.Name = "Numeroplaca";
            Numeroplaca.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // productos
            // 
            productos.FormattingEnabled = true;
            productos.Items.AddRange(new object[] { resources.GetString("productos.Items"), resources.GetString("productos.Items1"), resources.GetString("productos.Items2") });
            resources.ApplyResources(productos, "productos");
            productos.Name = "productos";
            productos.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // boxcantidad
            // 
            resources.ApplyResources(boxcantidad, "boxcantidad");
            boxcantidad.Name = "boxcantidad";
            boxcantidad.ReadOnly = true;
            boxcantidad.TextChanged += textBox1_TextChanged;
            // 
            // txtcantidad
            // 
            resources.ApplyResources(txtcantidad, "txtcantidad");
            txtcantidad.Name = "txtcantidad";
            txtcantidad.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // mecanicos
            // 
            mecanicos.FormattingEnabled = true;
            mecanicos.Items.AddRange(new object[] { resources.GetString("mecanicos.Items"), resources.GetString("mecanicos.Items1") });
            resources.ApplyResources(mecanicos, "mecanicos");
            mecanicos.Name = "mecanicos";
            mecanicos.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(mecanicos);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtcantidad);
            panel1.Controls.Add(boxcantidad);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(productos);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(Numeroplaca);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            panel1.Paint += panel1_Paint;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem, salirDeCuentaToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarClienteToolStripMenuItem, registrarVehiculoToolStripMenuItem, registrarProductoToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            resources.ApplyResources(opcionesToolStripMenuItem, "opcionesToolStripMenuItem");
            // 
            // registrarClienteToolStripMenuItem
            // 
            registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            resources.ApplyResources(registrarClienteToolStripMenuItem, "registrarClienteToolStripMenuItem");
            registrarClienteToolStripMenuItem.Click += registrarClienteToolStripMenuItem_Click;
            // 
            // registrarVehiculoToolStripMenuItem
            // 
            registrarVehiculoToolStripMenuItem.Name = "registrarVehiculoToolStripMenuItem";
            resources.ApplyResources(registrarVehiculoToolStripMenuItem, "registrarVehiculoToolStripMenuItem");
            registrarVehiculoToolStripMenuItem.Click += registrarVehiculoToolStripMenuItem_Click;
            // 
            // registrarProductoToolStripMenuItem
            // 
            registrarProductoToolStripMenuItem.Name = "registrarProductoToolStripMenuItem";
            resources.ApplyResources(registrarProductoToolStripMenuItem, "registrarProductoToolStripMenuItem");
            registrarProductoToolStripMenuItem.Click += registrarProductoToolStripMenuItem_Click;
            // 
            // salirDeCuentaToolStripMenuItem
            // 
            salirDeCuentaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            salirDeCuentaToolStripMenuItem.Name = "salirDeCuentaToolStripMenuItem";
            resources.ApplyResources(salirDeCuentaToolStripMenuItem, "salirDeCuentaToolStripMenuItem");
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(salirToolStripMenuItem, "salirToolStripMenuItem");
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            MainMenuStrip = menuStrip1;
            Name = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private Label label1;
        private Label label2;
        private ComboBox Numeroplaca;
        private Label label3;
        private Label label4;
        private ComboBox productos;
        private Label label5;
        private TextBox boxcantidad;
        private TextBox txtcantidad;
        private Button button1;
        private Button button2;
        private ComboBox mecanicos;
        private Label label6;
        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem registrarClienteToolStripMenuItem;
        private ToolStripMenuItem registrarVehiculoToolStripMenuItem;
        private ToolStripMenuItem registrarProductoToolStripMenuItem;
        private ToolStripMenuItem salirDeCuentaToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Label label7;
    }
}