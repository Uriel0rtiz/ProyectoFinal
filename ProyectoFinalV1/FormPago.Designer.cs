namespace ProyectoFinalV1
{
    partial class FormPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPago));
            label1_Titulo = new Label();
            textBox_NumeroTarjeta = new TextBox();
            textBox_NombreCuenta = new TextBox();
            textBox_MesTarjeta = new TextBox();
            textBox_YearTarjeta = new TextBox();
            textBox_CVVTarjeta = new TextBox();
            textBox_TotalCompra = new TextBox();
            button_Pagar = new Button();
            radioButton_Efectivo = new RadioButton();
            radioButton_Tarjeta = new RadioButton();
            panel3 = new Panel();
            panel2 = new Panel();
            PagoEfectivo = new Button();
            label3 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel8 = new Panel();
            label7 = new Label();
            panel7 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            panel6 = new Panel();
            panel5 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            PanelEfectivo = new Panel();
            panel11 = new Panel();
            textBox_Efectivo = new TextBox();
            label9 = new Label();
            label12 = new Label();
            panel16 = new Panel();
            textBox6 = new TextBox();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            PanelEfectivo.SuspendLayout();
            panel11.SuspendLayout();
            panel16.SuspendLayout();
            SuspendLayout();
            // 
            // label1_Titulo
            // 
            label1_Titulo.AutoSize = true;
            label1_Titulo.Font = new Font("Century Gothic", 11.25F);
            label1_Titulo.ForeColor = SystemColors.ActiveCaption;
            label1_Titulo.Location = new Point(56, 31);
            label1_Titulo.Name = "label1_Titulo";
            label1_Titulo.Size = new Size(137, 20);
            label1_Titulo.TabIndex = 0;
            label1_Titulo.Text = "Metodo de pago";
            // 
            // textBox_NumeroTarjeta
            // 
            textBox_NumeroTarjeta.BackColor = Color.FromArgb(23, 26, 33);
            textBox_NumeroTarjeta.BorderStyle = BorderStyle.None;
            textBox_NumeroTarjeta.Font = new Font("Century Gothic", 11.25F);
            textBox_NumeroTarjeta.ForeColor = Color.LightGray;
            textBox_NumeroTarjeta.Location = new Point(3, 2);
            textBox_NumeroTarjeta.Margin = new Padding(3, 2, 3, 2);
            textBox_NumeroTarjeta.Name = "textBox_NumeroTarjeta";
            textBox_NumeroTarjeta.Size = new Size(446, 19);
            textBox_NumeroTarjeta.TabIndex = 3;
            // 
            // textBox_NombreCuenta
            // 
            textBox_NombreCuenta.BackColor = Color.FromArgb(23, 26, 33);
            textBox_NombreCuenta.BorderStyle = BorderStyle.None;
            textBox_NombreCuenta.Font = new Font("Century Gothic", 11.25F);
            textBox_NombreCuenta.ForeColor = Color.LightGray;
            textBox_NombreCuenta.Location = new Point(3, 2);
            textBox_NombreCuenta.Margin = new Padding(3, 2, 3, 2);
            textBox_NombreCuenta.Name = "textBox_NombreCuenta";
            textBox_NombreCuenta.Size = new Size(446, 19);
            textBox_NombreCuenta.TabIndex = 4;
            // 
            // textBox_MesTarjeta
            // 
            textBox_MesTarjeta.BackColor = Color.FromArgb(23, 26, 33);
            textBox_MesTarjeta.BorderStyle = BorderStyle.None;
            textBox_MesTarjeta.Font = new Font("Century Gothic", 11.25F);
            textBox_MesTarjeta.ForeColor = Color.LightGray;
            textBox_MesTarjeta.Location = new Point(0, 2);
            textBox_MesTarjeta.Margin = new Padding(3, 2, 3, 2);
            textBox_MesTarjeta.Name = "textBox_MesTarjeta";
            textBox_MesTarjeta.PlaceholderText = "dd/mm";
            textBox_MesTarjeta.Size = new Size(72, 19);
            textBox_MesTarjeta.TabIndex = 5;
            textBox_MesTarjeta.TextAlign = HorizontalAlignment.Center;
            textBox_MesTarjeta.TextChanged += textBox_MesTarjeta_TextChanged;
            // 
            // textBox_YearTarjeta
            // 
            textBox_YearTarjeta.BackColor = Color.FromArgb(23, 26, 33);
            textBox_YearTarjeta.BorderStyle = BorderStyle.None;
            textBox_YearTarjeta.Font = new Font("Century Gothic", 11.25F);
            textBox_YearTarjeta.ForeColor = Color.LightGray;
            textBox_YearTarjeta.Location = new Point(3, 2);
            textBox_YearTarjeta.Margin = new Padding(3, 2, 3, 2);
            textBox_YearTarjeta.Name = "textBox_YearTarjeta";
            textBox_YearTarjeta.PlaceholderText = "yy";
            textBox_YearTarjeta.Size = new Size(72, 19);
            textBox_YearTarjeta.TabIndex = 6;
            textBox_YearTarjeta.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_CVVTarjeta
            // 
            textBox_CVVTarjeta.BackColor = Color.FromArgb(23, 26, 33);
            textBox_CVVTarjeta.BorderStyle = BorderStyle.None;
            textBox_CVVTarjeta.Font = new Font("Century Gothic", 11.25F);
            textBox_CVVTarjeta.ForeColor = Color.LightGray;
            textBox_CVVTarjeta.Location = new Point(0, 2);
            textBox_CVVTarjeta.Margin = new Padding(3, 2, 3, 2);
            textBox_CVVTarjeta.Name = "textBox_CVVTarjeta";
            textBox_CVVTarjeta.Size = new Size(43, 19);
            textBox_CVVTarjeta.TabIndex = 7;
            // 
            // textBox_TotalCompra
            // 
            textBox_TotalCompra.BackColor = Color.FromArgb(42, 71, 94);
            textBox_TotalCompra.BorderStyle = BorderStyle.None;
            textBox_TotalCompra.Font = new Font("Century Gothic", 11.25F);
            textBox_TotalCompra.ForeColor = SystemColors.InactiveCaption;
            textBox_TotalCompra.Location = new Point(209, 19);
            textBox_TotalCompra.Margin = new Padding(3, 2, 3, 2);
            textBox_TotalCompra.Name = "textBox_TotalCompra";
            textBox_TotalCompra.PlaceholderText = "Total compra";
            textBox_TotalCompra.Size = new Size(99, 19);
            textBox_TotalCompra.TabIndex = 8;
            textBox_TotalCompra.TextChanged += textBox_TotalCompra_TextChanged;
            // 
            // button_Pagar
            // 
            button_Pagar.BackColor = Color.FromArgb(23, 26, 33);
            button_Pagar.FlatAppearance.BorderSize = 0;
            button_Pagar.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            button_Pagar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            button_Pagar.FlatStyle = FlatStyle.Flat;
            button_Pagar.Font = new Font("Century Gothic", 11.25F);
            button_Pagar.ForeColor = Color.LightGray;
            button_Pagar.Location = new Point(22, 59);
            button_Pagar.Margin = new Padding(3, 2, 3, 2);
            button_Pagar.Name = "button_Pagar";
            button_Pagar.Size = new Size(286, 28);
            button_Pagar.TabIndex = 9;
            button_Pagar.Text = "Completar pago";
            button_Pagar.UseVisualStyleBackColor = false;
            button_Pagar.Click += button_Pagar_Click;
            // 
            // radioButton_Efectivo
            // 
            radioButton_Efectivo.AutoSize = true;
            radioButton_Efectivo.Font = new Font("Century Gothic", 11.25F);
            radioButton_Efectivo.ForeColor = SystemColors.ActiveCaption;
            radioButton_Efectivo.Location = new Point(221, 31);
            radioButton_Efectivo.Margin = new Padding(3, 2, 3, 2);
            radioButton_Efectivo.Name = "radioButton_Efectivo";
            radioButton_Efectivo.Size = new Size(88, 24);
            radioButton_Efectivo.TabIndex = 12;
            radioButton_Efectivo.TabStop = true;
            radioButton_Efectivo.Text = "Efectivo";
            radioButton_Efectivo.UseVisualStyleBackColor = true;
            radioButton_Efectivo.CheckedChanged += radioButton_Efectivo_CheckedChanged;
            // 
            // radioButton_Tarjeta
            // 
            radioButton_Tarjeta.AutoSize = true;
            radioButton_Tarjeta.Font = new Font("Century Gothic", 11.25F);
            radioButton_Tarjeta.ForeColor = SystemColors.ActiveCaption;
            radioButton_Tarjeta.Location = new Point(325, 31);
            radioButton_Tarjeta.Margin = new Padding(3, 2, 3, 2);
            radioButton_Tarjeta.Name = "radioButton_Tarjeta";
            radioButton_Tarjeta.Size = new Size(75, 24);
            radioButton_Tarjeta.TabIndex = 13;
            radioButton_Tarjeta.TabStop = true;
            radioButton_Tarjeta.Text = "Tarjeta";
            radioButton_Tarjeta.UseVisualStyleBackColor = true;
            radioButton_Tarjeta.CheckedChanged += radioButton_Tarjeta_CheckedChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(23, 26, 33);
            panel3.Controls.Add(label1_Titulo);
            panel3.Controls.Add(radioButton_Tarjeta);
            panel3.Controls.Add(radioButton_Efectivo);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(482, 82);
            panel3.TabIndex = 29;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(42, 71, 94);
            panel2.Controls.Add(PagoEfectivo);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button_Pagar);
            panel2.Controls.Add(textBox_TotalCompra);
            panel2.Location = new Point(82, 332);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 105);
            panel2.TabIndex = 30;
            // 
            // PagoEfectivo
            // 
            PagoEfectivo.BackColor = Color.FromArgb(23, 26, 33);
            PagoEfectivo.FlatAppearance.BorderSize = 0;
            PagoEfectivo.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            PagoEfectivo.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            PagoEfectivo.FlatStyle = FlatStyle.Flat;
            PagoEfectivo.Font = new Font("Century Gothic", 11.25F);
            PagoEfectivo.ForeColor = Color.LightGray;
            PagoEfectivo.Location = new Point(22, 59);
            PagoEfectivo.Margin = new Padding(3, 2, 3, 2);
            PagoEfectivo.Name = "PagoEfectivo";
            PagoEfectivo.Size = new Size(286, 28);
            PagoEfectivo.TabIndex = 11;
            PagoEfectivo.Text = "Completar pago";
            PagoEfectivo.UseVisualStyleBackColor = false;
            PagoEfectivo.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(22, 19);
            label3.Name = "label3";
            label3.Size = new Size(74, 24);
            label3.TabIndex = 1;
            label3.Text = "TOTAL:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(42, 81, 94);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel4);
            panel1.Location = new Point(12, 100);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 215);
            panel1.TabIndex = 31;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(404, 159);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 33;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(354, 159);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(23, 26, 33);
            panel8.Controls.Add(textBox_CVVTarjeta);
            panel8.Location = new Point(184, 159);
            panel8.Name = "panel8";
            panel8.Size = new Size(43, 27);
            panel8.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Century Gothic", 11.25F);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(184, 136);
            label7.Name = "label7";
            label7.Size = new Size(43, 20);
            label7.TabIndex = 13;
            label7.Text = "CVV";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(23, 26, 33);
            panel7.Controls.Add(textBox_YearTarjeta);
            panel7.Location = new Point(101, 159);
            panel7.Name = "panel7";
            panel7.Size = new Size(77, 27);
            panel7.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Century Gothic", 11.25F);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(101, 136);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 12;
            label6.Text = "Año";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Century Gothic", 11.25F);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(15, 136);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 11;
            label5.Text = "Mes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Century Gothic", 11.25F);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(15, 73);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 10;
            label2.Text = "NUMERO DE CUENTA";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(23, 26, 33);
            panel6.Controls.Add(textBox_MesTarjeta);
            panel6.Location = new Point(18, 159);
            panel6.Name = "panel6";
            panel6.Size = new Size(77, 27);
            panel6.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(23, 26, 33);
            panel5.Controls.Add(textBox_NumeroTarjeta);
            panel5.Location = new Point(15, 96);
            panel5.Name = "panel5";
            panel5.Size = new Size(452, 27);
            panel5.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Century Gothic", 11.25F);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(179, 20);
            label1.TabIndex = 9;
            label1.Text = "NOMBRE EN LA TARJETA";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(23, 26, 33);
            panel4.Controls.Add(textBox_NombreCuenta);
            panel4.Location = new Point(15, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(452, 27);
            panel4.TabIndex = 8;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(108, 103);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(412, 349);
            pictureBox3.TabIndex = 42;
            pictureBox3.TabStop = false;
            // 
            // PanelEfectivo
            // 
            PanelEfectivo.BackColor = Color.FromArgb(42, 81, 94);
            PanelEfectivo.Controls.Add(panel11);
            PanelEfectivo.Controls.Add(label9);
            PanelEfectivo.Controls.Add(label12);
            PanelEfectivo.Controls.Add(panel16);
            PanelEfectivo.Location = new Point(12, 100);
            PanelEfectivo.Name = "PanelEfectivo";
            PanelEfectivo.Size = new Size(482, 144);
            PanelEfectivo.TabIndex = 34;
            PanelEfectivo.Paint += PanelEfectivo_Paint;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(23, 26, 33);
            panel11.Controls.Add(textBox_Efectivo);
            panel11.Location = new Point(15, 96);
            panel11.Name = "panel11";
            panel11.Size = new Size(141, 27);
            panel11.TabIndex = 10;
            // 
            // textBox_Efectivo
            // 
            textBox_Efectivo.BackColor = Color.FromArgb(23, 26, 33);
            textBox_Efectivo.BorderStyle = BorderStyle.None;
            textBox_Efectivo.Font = new Font("Century Gothic", 11.25F);
            textBox_Efectivo.ForeColor = Color.LightGray;
            textBox_Efectivo.Location = new Point(0, 2);
            textBox_Efectivo.Margin = new Padding(3, 2, 3, 2);
            textBox_Efectivo.Name = "textBox_Efectivo";
            textBox_Efectivo.PlaceholderText = "Cantidad";
            textBox_Efectivo.Size = new Size(141, 19);
            textBox_Efectivo.TabIndex = 11;
            textBox_Efectivo.TextChanged += textBox_Efectivo_TextChanged_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 11.25F);
            label9.ForeColor = SystemColors.ActiveCaption;
            label9.Location = new Point(15, 73);
            label9.Name = "label9";
            label9.Size = new Size(141, 20);
            label9.TabIndex = 10;
            label9.Text = "Cantidad a pagar";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.FlatStyle = FlatStyle.Flat;
            label12.Font = new Font("Century Gothic", 11.25F);
            label12.ForeColor = SystemColors.ActiveCaption;
            label12.Location = new Point(15, 12);
            label12.Name = "label12";
            label12.Size = new Size(160, 20);
            label12.TabIndex = 9;
            label12.Text = "NOMBRE COMPLETO";
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(23, 26, 33);
            panel16.Controls.Add(textBox6);
            panel16.Location = new Point(15, 35);
            panel16.Name = "panel16";
            panel16.Size = new Size(452, 27);
            panel16.TabIndex = 8;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(23, 26, 33);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Century Gothic", 11.25F);
            textBox6.ForeColor = Color.LightGray;
            textBox6.Location = new Point(3, 2);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(446, 19);
            textBox6.TabIndex = 4;
            // 
            // FormPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 40, 56);
            ClientSize = new Size(511, 449);
            Controls.Add(PanelEfectivo);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPago";
            Opacity = 0.95D;
            Text = "FormPago";
            Load += FormPago_Load;
            MouseDown += FormPago_MouseDown;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            PanelEfectivo.ResumeLayout(false);
            PanelEfectivo.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1_Titulo;
        private TextBox textBox_NumeroTarjeta;
        private TextBox textBox_NombreCuenta;
        private TextBox textBox_MesTarjeta;
        private TextBox textBox_YearTarjeta;
        private TextBox textBox_CVVTarjeta;
        private TextBox textBox_TotalCompra;
        private Button button_Pagar;
        private RadioButton radioButton_Efectivo;
        private RadioButton radioButton_Tarjeta;
        private Panel panel3;
        private Panel panel2;
        private Label label3;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label2;
        private Panel panel6;
        private Panel panel5;
        private Label label1;
        private Panel panel4;
        private Panel panel7;
        private Panel panel8;
        private Label label7;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Panel PanelEfectivo;
        private Panel panel11;
        private TextBox textBox_Efectivo;
        private Label label9;
        private Label label12;
        private Panel panel16;
        private TextBox textBox6;
        private Button PagoEfectivo;
    }
}