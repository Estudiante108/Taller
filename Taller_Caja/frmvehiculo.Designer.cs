namespace Taller_Caja
{
    partial class frmvehiculo
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
            Combocliente = new ComboBox();
            txtmarca = new TextBox();
            txtModelo = new TextBox();
            txtano = new TextBox();
            txtplaca = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(51, 34);
            label1.Name = "label1";
            label1.Size = new Size(276, 38);
            label1.TabIndex = 0;
            label1.Text = "Registro de Vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 100);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "ID Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 183);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "Marca";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(314, 100);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 3;
            label4.Text = "Modelo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(314, 183);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 4;
            label5.Text = "Año ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(567, 100);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 5;
            label6.Text = "Placa";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(57, 127);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 6;
            // 
            // Combocliente
            // 
            Combocliente.FormattingEnabled = true;
            Combocliente.Location = new Point(56, 138);
            Combocliente.Name = "Combocliente";
            Combocliente.Size = new Size(204, 28);
            Combocliente.TabIndex = 7;
            Combocliente.SelectedIndexChanged += Combocliente_SelectedIndexChanged;
            // 
            // txtmarca
            // 
            txtmarca.Location = new Point(57, 223);
            txtmarca.Name = "txtmarca";
            txtmarca.Size = new Size(203, 27);
            txtmarca.TabIndex = 8;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(314, 139);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(203, 27);
            txtModelo.TabIndex = 9;
            // 
            // txtano
            // 
            txtano.Location = new Point(314, 223);
            txtano.Name = "txtano";
            txtano.Size = new Size(203, 27);
            txtano.TabIndex = 10;
            // 
            // txtplaca
            // 
            txtplaca.Location = new Point(567, 139);
            txtplaca.Name = "txtplaca";
            txtplaca.Size = new Size(203, 27);
            txtplaca.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(62, 318);
            button1.Name = "button1";
            button1.Size = new Size(198, 29);
            button1.TabIndex = 12;
            button1.Text = "Registrar Vehiculo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(314, 318);
            button2.Name = "button2";
            button2.Size = new Size(198, 29);
            button2.TabIndex = 13;
            button2.Text = "Volver atras";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // frmvehiculo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtplaca);
            Controls.Add(txtano);
            Controls.Add(txtModelo);
            Controls.Add(txtmarca);
            Controls.Add(Combocliente);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmvehiculo";
            Text = "frmvehiculo";
            Load += frmvehiculo_Load;
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
        private ComboBox Combocliente;
        private TextBox txtmarca;
        private TextBox txtModelo;
        private TextBox txtano;
        private TextBox txtplaca;
        private Button button1;
        private Button button2;
    }
}