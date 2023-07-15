namespace Taller_Caja
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtnombre = new TextBox();
            txtcontrasena = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(178, 115);
            label1.Name = "label1";
            label1.Size = new Size(114, 38);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(195, 219);
            label2.Name = "label2";
            label2.Size = new Size(85, 38);
            label2.TabIndex = 1;
            label2.Text = "Clave";
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(298, 126);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(219, 27);
            txtnombre.TabIndex = 2;
            txtnombre.TextChanged += txtnombre_TextChanged;
            // 
            // txtcontrasena
            // 
            txtcontrasena.Location = new Point(298, 230);
            txtcontrasena.Name = "txtcontrasena";
            txtcontrasena.Size = new Size(219, 27);
            txtcontrasena.TabIndex = 3;
            txtcontrasena.UseSystemPasswordChar = true;
            txtcontrasena.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(332, 320);
            button1.Name = "button1";
            button1.Size = new Size(139, 29);
            button1.TabIndex = 4;
            button1.Text = "Iniciar sesion ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtcontrasena);
            Controls.Add(txtnombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesion";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtnombre;
        private TextBox txtcontrasena;
        private Button button1;
    }
}