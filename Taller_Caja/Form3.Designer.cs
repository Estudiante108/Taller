namespace Taller_Caja
{
    partial class Form3
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtEstado = new TextBox();
            txtdescripcion = new TextBox();
            txtStock = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            boxproveedor = new ComboBox();
            boxtipoproducto = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(285, 38);
            label1.TabIndex = 0;
            label1.Text = "Registro de Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 63);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(369, 63);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 2;
            label3.Text = "Descripcion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 128);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "Precio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 128);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 4;
            label5.Text = "Stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(100, 193);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 5;
            label6.Text = "Estado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(287, 107);
            label7.Name = "label7";
            label7.Size = new Size(98, 20);
            label7.TabIndex = 6;
            label7.Text = "ID_Proveedor";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(97, 267);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 7;
            label8.Text = "Tipo_producto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(100, 86);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(197, 27);
            txtNombre.TabIndex = 8;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(100, 151);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(197, 27);
            txtPrecio.TabIndex = 9;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(100, 216);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(197, 27);
            txtEstado.TabIndex = 10;
            // 
            // txtdescripcion
            // 
            txtdescripcion.Location = new Point(369, 86);
            txtdescripcion.Name = "txtdescripcion";
            txtdescripcion.Size = new Size(197, 27);
            txtdescripcion.TabIndex = 11;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(369, 151);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(197, 27);
            txtStock.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(100, 357);
            button1.Name = "button1";
            button1.Size = new Size(466, 29);
            button1.TabIndex = 15;
            button1.Text = "Registrar producto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(boxproveedor);
            panel1.Controls.Add(boxtipoproducto);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(82, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 399);
            panel1.TabIndex = 16;
            // 
            // button2
            // 
            button2.Location = new Point(201, 321);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "Volver";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // boxproveedor
            // 
            boxproveedor.FormattingEnabled = true;
            boxproveedor.Location = new Point(287, 130);
            boxproveedor.Name = "boxproveedor";
            boxproveedor.Size = new Size(196, 28);
            boxproveedor.TabIndex = 1;
            boxproveedor.SelectedIndexChanged += boxproveedor_SelectedIndexChanged;
            // 
            // boxtipoproducto
            // 
            boxtipoproducto.FormattingEnabled = true;
            boxtipoproducto.Location = new Point(19, 204);
            boxtipoproducto.Name = "boxtipoproducto";
            boxtipoproducto.Size = new Size(196, 28);
            boxtipoproducto.TabIndex = 0;
            boxtipoproducto.SelectedIndexChanged += boxtipoproducto_SelectedIndexChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(698, 450);
            Controls.Add(button1);
            Controls.Add(txtStock);
            Controls.Add(txtdescripcion);
            Controls.Add(txtEstado);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagina - Registro de producto";
            Load += Form3_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtEstado;
        private TextBox txtdescripcion;
        private TextBox txtStock;
        private Button button1;
        private Panel panel1;
        private ComboBox boxproveedor;
        private ComboBox boxtipoproducto;
        private Button button2;
    }
}