namespace GUI
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
            cboPlatos = new ComboBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNom = new TextBox();
            numCantidad = new NumericUpDown();
            btnAgregar = new Button();
            lstPedido = new ListBox();
            lblTotal = new Label();
            rdoSalon = new RadioButton();
            rdoDelivery = new RadioButton();
            label4 = new Label();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            label5 = new Label();
            cboDistrito = new ComboBox();
            label6 = new Label();
            btnRegistrar = new Button();
            label7 = new Label();
            cboPago = new ComboBox();
            label8 = new Label();
            txtEfectivo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // cboPlatos
            // 
            cboPlatos.FormattingEnabled = true;
            cboPlatos.Location = new Point(439, 209);
            cboPlatos.Name = "cboPlatos";
            cboPlatos.Size = new Size(283, 28);
            cboPlatos.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.chifa_banner;
            pictureBox1.Location = new Point(7, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1155, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 212);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 2;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(380, 212);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 3;
            label2.Text = "Plato";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(728, 212);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 4;
            label3.Text = "Cantidad";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(82, 212);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(283, 27);
            txtNom.TabIndex = 5;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(807, 209);
            numCantidad.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(294, 27);
            numCantidad.TabIndex = 6;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(877, 299);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(179, 50);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar Plato";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lstPedido
            // 
            lstPedido.FormattingEnabled = true;
            lstPedido.Location = new Point(8, 541);
            lstPedido.Name = "lstPedido";
            lstPedido.Size = new Size(697, 204);
            lstPedido.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(807, 495);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(75, 20);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total: S/ 0";
            // 
            // rdoSalon
            // 
            rdoSalon.AutoSize = true;
            rdoSalon.Checked = true;
            rdoSalon.Location = new Point(115, 298);
            rdoSalon.Name = "rdoSalon";
            rdoSalon.Size = new Size(67, 24);
            rdoSalon.TabIndex = 10;
            rdoSalon.TabStop = true;
            rdoSalon.Text = "Salón";
            rdoSalon.UseVisualStyleBackColor = true;
            // 
            // rdoDelivery
            // 
            rdoDelivery.AutoSize = true;
            rdoDelivery.Location = new Point(15, 298);
            rdoDelivery.Name = "rdoDelivery";
            rdoDelivery.Size = new Size(84, 24);
            rdoDelivery.TabIndex = 11;
            rdoDelivery.Text = "Delivery";
            rdoDelivery.UseVisualStyleBackColor = true;
            rdoDelivery.CheckedChanged += rdoDelivery_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 259);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 12;
            label4.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Enabled = false;
            txtDireccion.Location = new Point(82, 252);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(281, 27);
            txtDireccion.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Enabled = false;
            txtTelefono.Location = new Point(453, 252);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(288, 27);
            txtTelefono.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Location = new Point(380, 255);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 15;
            label5.Text = "Telefono";
            // 
            // cboDistrito
            // 
            cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistrito.Enabled = false;
            cboDistrito.FormattingEnabled = true;
            cboDistrito.Location = new Point(822, 251);
            cboDistrito.Name = "cboDistrito";
            cboDistrito.Size = new Size(285, 28);
            cboDistrito.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(758, 255);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 17;
            label6.Text = "Distrito";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(652, 331);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(117, 50);
            btnRegistrar.TabIndex = 18;
            btnRegistrar.Text = "Registrar Pedido";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(219, 302);
            label7.Name = "label7";
            label7.Size = new Size(122, 20);
            label7.TabIndex = 19;
            label7.Text = "Metodo de pago";
            // 
            // cboPago
            // 
            cboPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPago.FormattingEnabled = true;
            cboPago.Location = new Point(369, 299);
            cboPago.Name = "cboPago";
            cboPago.Size = new Size(232, 28);
            cboPago.TabIndex = 20;
            cboPago.SelectedIndexChanged += cboPago_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(771, 388);
            label8.Name = "label8";
            label8.Size = new Size(127, 20);
            label8.TabIndex = 21;
            label8.Text = "Dinero Entregado";
            // 
            // txtEfectivo
            // 
            txtEfectivo.Enabled = false;
            txtEfectivo.Location = new Point(935, 385);
            txtEfectivo.Name = "txtEfectivo";
            txtEfectivo.Size = new Size(166, 27);
            txtEfectivo.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 827);
            Controls.Add(txtEfectivo);
            Controls.Add(label8);
            Controls.Add(cboPago);
            Controls.Add(label7);
            Controls.Add(btnRegistrar);
            Controls.Add(label6);
            Controls.Add(cboDistrito);
            Controls.Add(label5);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(label4);
            Controls.Add(rdoDelivery);
            Controls.Add(rdoSalon);
            Controls.Add(lblTotal);
            Controls.Add(lstPedido);
            Controls.Add(btnAgregar);
            Controls.Add(numCantidad);
            Controls.Add(txtNom);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(cboPlatos);
            Name = "Form1";
            Text = "Chifa chi- Sistema de Registo de Pedidos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPlatos;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNom;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private ListBox lstPedido;
        private Label lblTotal;
        private RadioButton rdoSalon;
        private RadioButton rdoDelivery;
        private Label label4;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private Label label5;
        private ComboBox cboDistrito;
        private Label label6;
        private Button btnRegistrar;
        private Label label7;
        private ComboBox cboPago;
        private Label label8;
        private TextBox txtEfectivo;
    }
}
