namespace GUI
{
    public partial class Form1 : Form
    {
        List<string> platos = new List<string>
{
    "Arroz chaufa", "Tallarín saltado", "Pollo con verduras", "Pollo Chi Jau Kay",
    "Pollo Tipakay", "Aeropuerto", "Lomo saltado", "Kam Lu Wantán", "Wantán frito",
    "Sopa wantán", "Rollito primavera", "Inca Kola", "Coca-Cola", "Chicha morada", "Limonada"
};
        double total = 0;
        double ObtenerCostoDelivery(string distrito)
        {
            switch (distrito)
            {
                case "San Martín de Porres": return 3;
                case "Los Olivos":
                case "Independencia": return 4;
                case "Rímac": return 5;
                case "Comas":
                case "Cercado de Lima": return 6;
                case "Carmen de la Legua-Reynoso":
                case "Callao": return 7;
                case "Puente Piedra": return 8;
                case "Ventanilla": return 10;
                default: return 0;
            }
        }
        double ObtenerPrecio(string plato)
        {
            switch (plato)
            {
                case "Arroz chaufa": return 15;
                case "Tallarín saltado": return 16;
                case "Pollo con verduras": return 18;
                case "Pollo Chi Jau Kay": return 20;
                case "Pollo Tipakay": return 20;
                case "Aeropuerto": return 17;
                case "Lomo saltado": return 22;
                case "Kam Lu Wantán": return 20;
                case "Wantán frito": return 8;
                case "Sopa wantán": return 10;
                case "Rollito primavera": return 7;
                case "Inca Kola": return 4;
                case "Coca-Cola": return 4;
                case "Chicha morada": return 5;
                case "Limonada": return 5;
                default: return 0;
            }
        }
        public Form1()
        {
            InitializeComponent();
            cboPlatos.Items.AddRange(platos.ToArray());
            cboPlatos.SelectedIndex = 0;
            cboDistrito.Items.AddRange(new string[]
{
    "San Martín de Porres", "Los Olivos", "Independencia", "Rímac", "Comas",
    "Puente Piedra", "Cercado de Lima", "Callao", "Carmen de la Legua-Reynoso", "Ventanilla"
});
            cboDistrito.SelectedIndex = 0;
            cboPago.Items.AddRange(new string[] { "Yape", "Plin", "Tarjeta", "Efectivo" });
            cboPago.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNom.Text.Trim();
            if (nombre == "" || !nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Ingrese un nombre válido (solo letras y espacios).");
                txtNom.Focus();
                return;
            }
            string plato = cboPlatos.SelectedItem?.ToString() ?? "";
            int cantidad = (int)numCantidad.Value;
            double subtotal = ObtenerPrecio(plato) * cantidad;
            lstPedido.Items.Add(cantidad + " x " + plato + " - S/ " + subtotal);
            total += subtotal;
            lblTotal.Text = "Total: S/ " + total;
        }

        private void rdoDelivery_CheckedChanged(object sender, EventArgs e)
        {
            txtDireccion.Enabled = rdoDelivery.Checked;
            txtTelefono.Enabled = rdoDelivery.Checked;
            cboDistrito.Enabled = rdoDelivery.Checked;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNom.Text.Trim();
            if (nombre == "" || !nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Ingrese un nombre válido (solo letras y espacios).");
                return;
            }
            if (lstPedido.Items.Count == 0)
            {
                MessageBox.Show("Agregue al menos un plato al pedido.");
                return;
            }
            double costoDelivery = 0;
            string tipo = "Salón";
            if (rdoDelivery.Checked)
            {
                string telefono = txtTelefono.Text.Trim();
                if (txtDireccion.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la dirección.");
                    return;
                }
                if (telefono.Length != 9 || !telefono.All(char.IsDigit))
                {
                    MessageBox.Show("El teléfono debe tener exactamente 9 dígitos.");
                    return;
                }
                costoDelivery = ObtenerCostoDelivery(cboDistrito.SelectedItem?.ToString() ?? "");
                tipo = "Delivery a " + cboDistrito.SelectedItem;
            }
            double totalFinal = total + costoDelivery;
            string metodo = cboPago.SelectedItem?.ToString() ?? "";
            string mensajePago = "Pago con " + metodo;
            if (metodo == "Efectivo")
            {
                if (!double.TryParse(txtEfectivo.Text, out double entregado) || entregado < totalFinal)
                {
                    MessageBox.Show("El dinero entregado debe ser un número mayor o igual al total.");
                    return;
                }
                mensajePago += "\nVuelto: S/ " + (entregado - totalFinal);
            }
            MessageBox.Show("Pedido de " + nombre + "\n" + tipo + "\nDelivery: S/ " + costoDelivery + "\nTotal a pagar: S/ " + totalFinal + "\n" + mensajePago);
            lstPedido.Items.Clear();
            total = 0;
            lblTotal.Text = "Total: S/ 0";
            txtNom.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEfectivo.Clear();
            cboPago.SelectedIndex = 0;
            rdoSalon.Checked = true;
        }

        private void cboPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEfectivo.Enabled = cboPago.SelectedItem?.ToString() == "Efectivo";
            if (!txtEfectivo.Enabled)
            {
                txtEfectivo.Clear();
            }
        }
    }
}
