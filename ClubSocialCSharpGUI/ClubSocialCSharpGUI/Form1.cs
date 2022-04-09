using ClubSocialCSharpGUI.Code;

namespace ClubSocialCSharpGUI {
    public partial class formularioPrincipalClubSocial : Form {

        private ClubSocial clubSocial;
        public formularioPrincipalClubSocial() {
            clubSocial = new ClubSocial();
            InitializeComponent();
            centrarPaneles();
        }

        public void ocultarPaneles() {
            panelAfiliarSocio.Visible = false;
            panelListarSocio.Visible = false;
            panelListarFacturasSocio.Visible = false;
            panelAniadirFacturaSocio.Visible = false;
            panelListarFondosDisponiblesSocio.Visible = false;
            panelAfiliarPersonaAutorizada.Visible = false;
            panelListarPersonaA.Visible = false;
            panelAniadirFacturaPersonaAu.Visible = false;
            panelListarFacturaPersonaA.Visible = false;
            panelComboBoxBebida.Visible = false;
            panelSocioAniadirFacturaPersonaAu.Visible = false;
        }

        public void ConsultarFondosDisponiblesSocio() {
            String cedulaSocioCadena = comboBoxSocioFondosDisponibles.Text;
            if (!cedulaSocioCadena.Equals("")) {
                int cedulaSocio = Int32.Parse(cedulaSocioCadena.Split(")")[0].Replace("(", ""));
                String fondosDisponiblesSocio = clubSocial.VerFondosDisponiblesSocio(cedulaSocio);
                if (fondosDisponiblesSocio != null) {
                    textBoxSaldoFondosDisponiblesSocio.Text = "$ " + fondosDisponiblesSocio;
                }
            } else MessageBox.Show("Error, debe seleccionar un socio.");
        }

        public void crearFilasTablaListarFacturaPersonaA() {
            tablaListarFacturaPersonaA.Rows.Clear();
            String cedulaPersonaACadena = comboBoxPersonaAListarFacturaPersonaA.Text;
            if (!cedulaPersonaACadena.Equals("")) {
                int cedulaPersonaA = Int32.Parse(cedulaPersonaACadena.Split(")")[0].Replace("(", ""));
                float totalFactura = 0;
                List<List<String>> listaFacturas = clubSocial.VerFacturasPersonaAutorizada(cedulaPersonaA);
                foreach (List<String> filaListaFacturasPersonaA in listaFacturas) {
                    tablaListarFacturaPersonaA.Rows.Add(tablaListarFacturaPersonaA.Rows.Count + 1,
                        filaListaFacturasPersonaA[0], filaListaFacturasPersonaA[1]);
                    totalFactura += float.Parse(filaListaFacturasPersonaA[1]);
                }
                if (tablaListarFacturaPersonaA.Rows.Count > 0) tablaListarFacturaPersonaA.Rows.Add("----", "Total", totalFactura);
            } else MessageBox.Show("Error, debe seleccionar una persona autorizada.");
        }

        public void crearFilasTablaListarFacturaSocio() {
            tablaListarFacturaSocio.Rows.Clear();
            comboBoxListarFacturaSocio.Items.Clear();
            String cedulaSocioCadena = comboBoxSocioListarFactura.Text;
            if (!cedulaSocioCadena.Equals("")) {
                int cedulaSocio = Int32.Parse(cedulaSocioCadena.Split(")")[0].Replace("(", ""));
                float totalFacturas = 0;
                List<List<String>> listaFacturas = clubSocial.VerFacturasSocio(cedulaSocio);
                foreach (List<String> filaListaFacturasSocio in listaFacturas) {
                    tablaListarFacturaSocio.Rows.Add(filaListaFacturasSocio[0],
                        filaListaFacturasSocio[1], filaListaFacturasSocio[2]);
                    comboBoxListarFacturaSocio.Items.Add("(" +
                        filaListaFacturasSocio[0] + ") " + filaListaFacturasSocio[1]);
                    totalFacturas += float.Parse(filaListaFacturasSocio[2]);
                }
                String fondosDisponiblesSocio = clubSocial.VerFondosDisponiblesSocio(cedulaSocio);
                if (fondosDisponiblesSocio != null) {
                    textBoxFondosListarFacturaSocio.Text = "$ " + fondosDisponiblesSocio;
                }
                if (tablaListarFacturaSocio.Rows.Count > 0) tablaListarFacturaSocio.Rows.Add("----", "Total", totalFacturas);
            } else MessageBox.Show("Error, debe seleccionar un socio");
        }

        public void crearFilasTablaListarPersonaA() {
            tablaListarPersonaA.Rows.Clear();
            comboBoxListarPersonaA.Items.Clear();
            String cedulaSocioRCadena = comboBoxSocioRPesonaA.Text;
            if (!cedulaSocioRCadena.Equals("")) {
                int cedulaSocioR = Int32.Parse(cedulaSocioRCadena.Split(")")[0].Replace("(", ""));
                List<List<String>> listaPersonasA = clubSocial.VerPersonasAutorizadasSocio(cedulaSocioR);
                foreach (List<String> filaListaPersonasA in listaPersonasA) {
                    tablaListarPersonaA.Rows.Add(tablaListarPersonaA.Rows.Count + 1, filaListaPersonasA[0],
                        filaListaPersonasA[1]);
                    comboBoxListarPersonaA.Items.Add("(" + filaListaPersonasA[0] + ") " + filaListaPersonasA[1]);
                }
            } else MessageBox.Show("Error, debe seleccionar un socio.");
        }

        public void crearFilasTablaListarSocio() {
            tablaListarSocio.Rows.Clear();
            comboBoxListarSocio.Items.Clear();
            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                tablaListarSocio.Rows.Add(tablaListarSocio.Rows.Count + 1, filaListaSocios[0],
                    filaListaSocios[1], filaListaSocios[2]);
                comboBoxListarSocio.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        public void centrarPaneles() {
            int xPosition = 300;
            int yPosition = 150;
            panelAfiliarSocio.Location = new Point(xPosition, yPosition);
            panelListarSocio.Location = new Point(xPosition, yPosition);
            panelListarFacturasSocio.Location = new Point(xPosition, yPosition);
            panelAniadirFacturaSocio.Location = new Point(190, 110);
            panelListarFondosDisponiblesSocio.Location = new Point(xPosition, yPosition);
            panelAfiliarPersonaAutorizada.Location = new Point(xPosition, yPosition);
            panelListarPersonaA.Location = new Point(xPosition, yPosition);
            panelSocioAniadirFacturaPersonaAu.Location = new Point(xPosition + 450, yPosition + 150);
            panelListarFacturaPersonaA.Location = new Point(xPosition, yPosition);
            panelComboBoxBebida.Location = new Point(xPosition + 50, yPosition + 150);
            panelAniadirFacturaPersonaAu.Location = new Point(190, 110);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click_1(object sender, EventArgs e) {
            ocultarPaneles();
            panelAfiliarSocio.Visible = true;

            comboBoxSuscripcionSocioAfiliar.SelectedItem = "VIP";
            textBoxCedulaSocioAfiliar.Text = "";
            textBoxNombreSocioAfiliar.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelListarSocio.Visible = true;

            crearFilasTablaListarSocio();
        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelAniadirFacturaSocio.Visible = true;
            tablaAdicionesAniadirFacturaSocio.Rows.Clear();
            tablaIngredientesAniadirFacturaSocio.Rows.Clear();

            comboBoxSocioAniadirFactura.Items.Clear();
            textBoxFondosAniadirFactura.Text = "";
            textBoxValorAniadirFactura.Text = "";
            comboBoxCategoriaAniadirFactura.SelectedIndex = -1;

            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioAniadirFactura.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void labelMenuIzquierdoPersonaAutorizada_Click(object sender, EventArgs e) {

        }

        private void formularioPrincipalClubSocial_Load(object sender, EventArgs e) {

        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void panelAfiliarSocio_Paint(object sender, PaintEventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            tablaIngredientesAniadirFacturaSocio.Rows.Clear();
            tablaAdicionesAniadirFacturaSocio.Rows.Clear();
            comboBoxAdicionAniadirFacturaSocio.Enabled = true;
            switch (comboBoxProductoAniadirFactura.Text) {
                case "Papas con queso cheddar y tocineta": {
                        textBoxValorAniadirFactura.Text = "$ 15000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Queso cheddar");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Tocineta");
                        break;
                    }
                case "Empanadas de arroz y carne (5)": {
                        textBoxValorAniadirFactura.Text = "$ 10000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Masa de maiz");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Arroz");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Carne");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Guiso");
                        break;
                    }
                case "Patacones con hogao (5)": {
                        textBoxValorAniadirFactura.Text = "$ 5000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Platano verde");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Hogao");
                        break;
                    }
                case "Tres leches": {
                        textBoxValorAniadirFactura.Text = "$ 8000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche en polvo");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Lecherita");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Galleta sultan");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Gelatina sin sabor");
                        break;
                    }
                case "Milo": {
                        textBoxValorAniadirFactura.Text = "$ 9000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Milo");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Nuggets milo");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Gelatina sin sabor");
                        break;
                    }
                case "Oreo": {
                        textBoxValorAniadirFactura.Text = "$ 9000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Galleta oreo");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Gelatina sin sabor");
                        break;
                    }
                case "Punta de anca": {
                        textBoxValorAniadirFactura.Text = "$ 30000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Ensalada de lechuga y tomate");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Arepa con queso mazarella");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Carne punta de anca");
                        panelAniadirFacturaSocio.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Pollito a la plancha": {
                        textBoxValorAniadirFactura.Text = "$ 26000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Pechuga de pollo");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Ensalada de lechuga y tomate");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Arepa con queso mazarella");
                        panelAniadirFacturaSocio.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Trucha": {
                        textBoxValorAniadirFactura.Text = "$ 28000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Ensalada de lechuga y tomate");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Arepa con queso mazarella");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Trucha");
                        panelAniadirFacturaSocio.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Pizza vegana (6 porciones)": {
                        textBoxValorAniadirFactura.Text = "$ 21000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Masa de pizza");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Lechuga");
                        panelAniadirFacturaSocio.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Pasta vegana": {
                        textBoxValorAniadirFactura.Text = "$ 20000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Pasta");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Lechuga");
                        panelAniadirFacturaSocio.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Ensaladita": {
                        textBoxValorAniadirFactura.Text = "$ 16000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Lechuga");
                        panelAniadirFacturaSocio.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Crema de whisky (700 ml)[Baileys]": {
                        textBoxValorAniadirFactura.Text = "$ 80000";
                        break;
                    }
                case "Guarito barato (2000 ml)[Aguardiente Antioqueño]": {
                        textBoxValorAniadirFactura.Text = "$ 100000";
                        break;
                    }
                case "Limoncito con ron (750 ml)[Ron viejo de Caldas]": {
                        textBoxValorAniadirFactura.Text = "$ 50000";
                        break;
                    }
                case "Milito (500 ml)[Nestle]": {
                        textBoxValorAniadirFactura.Text = "$ 4000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Milo");
                        break;
                    }
                case "Jugo de naranja (500 ml)[Frutiño]": {
                        textBoxValorAniadirFactura.Text = "$ 3000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Agua");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Naranja");
                        break;
                    }
                case "Avena (500 ml)[Alpina]": {
                        textBoxValorAniadirFactura.Text = "$ 2500";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Avena");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Azucar");
                        break;
                    }
                case "Cafe (200 ml)": {
                        textBoxValorAniadirFactura.Text = "$ 2000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Agua o leche");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Cafe");
                        break;
                    }
                case "Chocolate (350 ml)": {
                        textBoxValorAniadirFactura.Text = "$ 2500";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "AguaPanela");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Chocolate");
                        break;
                    }
                case "Milito (500 ml)": {
                        textBoxValorAniadirFactura.Text = "$ 4000";
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaSocio.Rows.Add(tablaIngredientesAniadirFacturaSocio.Rows.Count, "Milo");
                        break;
                    }
                default: {
                        textBoxValorAniadirFactura.Text = "0";
                        break;
                    }
            }
        }

        private void botonVerPagarFacturasSocio_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelListarFacturasSocio.Visible = true;
            textBoxFondosListarFacturaSocio.Text = "";

            comboBoxSocioListarFactura.Items.Clear();
            comboBoxListarFacturaSocio.Items.Clear();
            tablaListarFacturaSocio.Rows.Clear();
            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioListarFactura.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void botonVerAumentarFondosSocio_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelListarFondosDisponiblesSocio.Visible = true;

            textBoxAumentoFondosDisponiblesSocio.Text = "";
            textBoxSaldoFondosDisponiblesSocio.Text = "";
            comboBoxSocioFondosDisponibles.Items.Clear();

            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioFondosDisponibles.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void botonCancelarSocioAfiliar_Click(object sender, EventArgs e) {
            panelAfiliarSocio.Visible = false;
        }

        private void botonCancelarAniadirFactura_Click(object sender, EventArgs e) {
            panelAniadirFacturaSocio.Visible = false;
        }

        private void botonCancelarFondosDisponiblesSocio_Click(object sender, EventArgs e) {
            panelListarFondosDisponiblesSocio.Visible = false;
        }

        private void botonRegistrarSocioAfiliar_Click(object sender, EventArgs e) {
            String cedulaSocio = textBoxCedulaSocioAfiliar.Text;
            String nombreSocio = textBoxNombreSocioAfiliar.Text;
            String tipoSuscripcion = comboBoxSuscripcionSocioAfiliar.Text;
            if (!cedulaSocio.Equals("") && !nombreSocio.Equals("") && !tipoSuscripcion.Equals("")) {
                if (clubSocial.AfiliarSocio(cedulaSocio, nombreSocio, tipoSuscripcion)) {
                    textBoxCedulaSocioAfiliar.Text = "";
                    textBoxNombreSocioAfiliar.Text = "";
                }
            } else {
                MessageBox.Show("Error, debe rellenar todos los campos.");
            }
        }

        private void botonEliminarListarSocio_Click(object sender, EventArgs e) {
            String cedulaSocioCadena = comboBoxListarSocio.Text.Split(")")[0].Replace("(", "");
            if (!cedulaSocioCadena.Equals("")) {
                int cedulaSocio = Int32.Parse(cedulaSocioCadena);
                if (clubSocial.EliminarSocio(cedulaSocio)) {
                    crearFilasTablaListarSocio();
                }
            } else MessageBox.Show("Error debe seleccionar un socio.");
        }

        private void botonRegistrarAniadirFactura_Click(object sender, EventArgs e) {
            String cedulaSocioCadena = comboBoxSocioAniadirFactura.Text;
            if (!cedulaSocioCadena.Equals("")) {
                String ingredientes = "";
                Consumo consumo = null;
                int cedulaSocio = Int32.Parse(cedulaSocioCadena.Split(")")[0].Replace("(", ""));
                float valorFactura = float.Parse(textBoxValorAniadirFactura.Text.Replace("$", "").Replace(" ", "").Replace(".", ""));
                switch (comboBoxCategoriaAniadirFactura.Text) {
                    case "Entrada": {
                            List<String> listaSalsas = new List<String>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaSocio.Rows.Count; i++) {
                                listaSalsas.Add(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString());
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaSocio.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString();
                                if (i != tablaIngredientesAniadirFacturaSocio.Rows.Count - 1) ingredientes += ", ";
                            }
                            consumo = new EntradaPlato(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], ingredientes, true, listaSalsas);
                            break;
                        }
                    case "Postre": {
                            List<String> listaEndulzantes = new List<String>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaSocio.Rows.Count; i++) {
                                listaEndulzantes.Add(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString());
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaSocio.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString();
                                if (i != tablaIngredientesAniadirFacturaSocio.Rows.Count - 1) ingredientes += ", ";
                            }
                            consumo = new PostrePlato(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], ingredientes, listaEndulzantes);
                            break;
                        }
                    case "Plato fuerte mixto": {
                            String bebida = comboBoxBebidaFria.Text;
                            int gramajeAzucar = Int32.Parse(comboBoxGramajeAzucar.Text.Replace("g", ""));
                            List<String> listaSalsas = new List<String>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaSocio.Rows.Count; i++) {
                                listaSalsas.Add(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString());
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaSocio.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString;
                                if (i != tablaIngredientesAniadirFacturaSocio.Rows.Count - 1) ingredientes += ", ";
                            }
                            NoAlcoholicaFriaBebida bebidaFriaNoAlcoholica = 
                                new NoAlcoholicaFriaBebida(bebida.Split("(")[0], 0.0, comboBoxSocioAniadirFactura.Text.Split(")")[1], Int32.Parse(bebida.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", "")), 
                                bebida.Split("[")[1].Replace("]", ""), gramajeAzucar);
                            consumo = new MixtoFuertePlato(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], ingredientes, bebidaFriaNoAlcoholica, listaSalsas);
                            break;
                        }
                    case "Plato fuerte vegano": {
                            String bebida = comboBoxBebidaFria.Text;
                            int gramajeAzucar = Int32.Parse(comboBoxGramajeAzucar.Text.Replace("g", ""));
                            Dictionary<String, double> diccionarioAdiciones = new Dictionary<String, double>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaSocio.Rows.Count; i++) {
                                diccionarioAdiciones.Add(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString().Split(" -")[0],
                                    double.Parse(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString().Split(" -")[1].Replace(" $ ", "")));
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaSocio.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString();
                                if (i != tablaIngredientesAniadirFacturaSocio.Rows.Count - 1) ingredientes += ", ";
                            }
                            NoAlcoholicaFriaBebida bebidaFriaNoAlcoholica =
                                new NoAlcoholicaFriaBebida(bebida.Split("(")[0], 0.0, comboBoxSocioAniadirFactura.Text.Split(")")[1], Int32.Parse(bebida.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", "")),
                                bebida.Split("[")[1].Replace("]", ""), gramajeAzucar);
                            consumo = new VeganoFuertePlato(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], ingredientes, bebidaFriaNoAlcoholica, diccionarioAdiciones);
                            break;
                        }
                    case "Bebida fria alcoholica": {
                            String marcaBebida = comboBoxProductoAniadirFactura.Text.Split("[")[1].Replace("]", "");
                            int tamanio = Int32.Parse(comboBoxProductoAniadirFactura.Text.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", ""));
                            int gradoAlcohol = Int32.Parse(comboBoxAdicionAniadirFacturaSocio.Text.Replace("°", ""));
                            consumo = new AlcoholicaFriaBebida(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], tamanio, marcaBebida, gradoAlcohol);
                            break;
                        }
                    case "Bebida fria no alcoholica": {
                            String marcaBebida = comboBoxProductoAniadirFactura.Text.Split("[")[1].Replace("]", "");
                            int tamanio = Int32.Parse(comboBoxProductoAniadirFactura.Text.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", ""));
                            int gramajeAzucar = Int32.Parse(comboBoxAdicionAniadirFacturaSocio.Text.Replace("g", ""));
                            consumo = new NoAlcoholicaFriaBebida(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], tamanio, marcaBebida, gramajeAzucar);
                            break;
                        }
                    case "Bebida caliente": {
                            int tamanio = Int32.Parse(comboBoxProductoAniadirFactura.Text.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", ""));
                            Dictionary<String, double> diccionarioAdiciones = new Dictionary<String, double>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaSocio.Rows.Count; i++) {
                                diccionarioAdiciones.Add(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString().Split(" -")[0],
                                    double.Parse(tablaAdicionesAniadirFacturaSocio.Rows[i].Cells[1].Value.ToString().Split(" -")[1].Replace(" $ ", "")));
                            }
                            consumo = new CalienteBebida(comboBoxProductoAniadirFactura.Text, float.Parse(textBoxValorAniadirFactura.Text.Replace("$ ", "")), comboBoxSocioAniadirFactura.Text.Split(")")[1], tamanio, diccionarioAdiciones);
                            break;
                        }
                }
                clubSocial.RegistrarFacturaSocio(consumo, cedulaSocio);
            } else {
                MessageBox.Show("Error, debe seleccionar un socio.");
            }
        }

        private void panelAniadirFacturaSocio_Paint(object sender, PaintEventArgs e) {

        }

        private void label1_Click_1(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) {

        }

        private void botonListarFacturaSocio_Click(object sender, EventArgs e) {

        }

        private void botonPagarListarFacturaSocio_Click(object sender, EventArgs e) {
            String cedulaSocioCadena = comboBoxSocioListarFactura.Text;
            if (!cedulaSocioCadena.Equals("")) {
                int cedulaSocio = Int32.Parse(cedulaSocioCadena.Split(")")[0].Replace("(", ""));
                if (!comboBoxListarFacturaSocio.Text.Equals("")) {
                    int indiceFactura = Int32.Parse(comboBoxListarFacturaSocio.Text.Split(")")[0].Replace("(", ""));
                    if (clubSocial.PagarFacturaSocio(cedulaSocio, indiceFactura)) {
                        crearFilasTablaListarFacturaSocio();
                    }
                } else {
                    MessageBox.Show("Error, debe seleccionar una factura a pagar.");
                }
            } else {
                MessageBox.Show("Error, debe seleccionar un socio.");
            }
        }

        private void botonConsularFondosDisponiblesSocio_Click(object sender, EventArgs e) {

        }

        private void botonAumentarFondosDisponiblesSocio_Click(object sender, EventArgs e) {
            String cedulaSocioCadena = comboBoxSocioFondosDisponibles.Text;
            String aumentoFondosSocioCadena = textBoxAumentoFondosDisponiblesSocio.Text;
            if (!cedulaSocioCadena.Equals("")) {
                if (!aumentoFondosSocioCadena.Equals("")) {
                    try {
                        float aumentoFondosSocio = float.Parse(aumentoFondosSocioCadena);
                        int cedulaSocio = Int32.Parse(cedulaSocioCadena.Split(")")[0].Replace("(", ""));
                        if (clubSocial.AumentarFondosSocio(cedulaSocio, aumentoFondosSocio)) {
                            ConsultarFondosDisponiblesSocio();
                            textBoxAumentoFondosDisponiblesSocio.Text = "";
                        }
                    } catch (Exception) {
                        MessageBox.Show("Error, debe ingresar un aumento valido.");
                    }
                } else MessageBox.Show("Error, digite un aumento.");
            } else MessageBox.Show("Error, debe seleccionar un socio.");
        }

        private void botonConsultarFondosAniadirFactura_Click(object sender, EventArgs e) {

        }

        private void botonRegistrarPersonaAutorizada_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelAfiliarPersonaAutorizada.Visible = true;
            comboBoxSocioRAfiliarPersonaA.Items.Clear();
            textBoxCedulaPersonaA.Text = "";
            textBoxNombrePersonaA.Text = "";

            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioRAfiliarPersonaA.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void botonRegistrarPersonaA_Click(object sender, EventArgs e) {
            String socioResponsableCadena = comboBoxSocioRAfiliarPersonaA.Text;
            String cedulaPersonaACadena = textBoxCedulaPersonaA.Text;
            String nombrePersonaA = textBoxNombrePersonaA.Text;
            if (!socioResponsableCadena.Equals("")) {
                if (!cedulaPersonaACadena.Equals("") && !nombrePersonaA.Equals("")) {
                    try {
                        int cedulaPersonaA = Int32.Parse(cedulaPersonaACadena);
                        int cedulaSocio = Int32.Parse(socioResponsableCadena.Split(")")[0].Replace("(", ""));
                        if (clubSocial.RegistrarPersonaAutorizadaASocio(cedulaSocio, cedulaPersonaA, nombrePersonaA)) {
                            textBoxCedulaPersonaA.Text = "";
                            textBoxNombrePersonaA.Text = "";
                        }
                    } catch (Exception) {
                        MessageBox.Show("Error, debe digitar una cedula valida");
                    }
                } else MessageBox.Show("Error, debe llenar todos los campos.");
            } else MessageBox.Show("Error, debe seleccionar un socio responsable.");
        }

        private void botonCancelarPersonaA_Click(object sender, EventArgs e) {
            panelAfiliarPersonaAutorizada.Visible = false;
        }

        private void botonListarEliminarPersonaAutorizada_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelListarPersonaA.Visible = true;

            tablaListarPersonaA.Rows.Clear();
            comboBoxSocioRPesonaA.Items.Clear();
            comboBoxListarPersonaA.Items.Clear();
            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioRPesonaA.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void botonListarPersonaA_Click(object sender, EventArgs e) {

        }

        private void botonEliminarPersonaA_Click(object sender, EventArgs e) {
            String cedulaPersonaACadena = comboBoxListarPersonaA.Text.Split(")")[0].Replace("(", "");
            if (!cedulaPersonaACadena.Equals("")) {
                int cedulaPersonaA = Int32.Parse(cedulaPersonaACadena);
                if (clubSocial.EliminarPersonaAutorizada(cedulaPersonaA)) {
                    crearFilasTablaListarPersonaA();
                }
            } else MessageBox.Show("Error, debe seleccionar una persona autorizada.");
        }

        private void comboBoxSocioRPesonaA_SelectedIndexChanged(object sender, EventArgs e) {
            crearFilasTablaListarPersonaA();
        }

        private void comboBoxListarSocio_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {
            crearFilasTablaListarFacturaSocio();
        }

        private void comboBoxSocioRAfiliarPersonaA_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void comboBoxSocioAniadirFactura_SelectedIndexChanged(object sender, EventArgs e) {
            String cedulaSocioCadena = comboBoxSocioAniadirFactura.Text;
            if (!cedulaSocioCadena.Equals("")) {
                int cedulaSocio = Int32.Parse(cedulaSocioCadena.Split(")")[0].Replace("(", ""));
                String fondosDisponiblesSocio = clubSocial.VerFondosDisponiblesSocio(cedulaSocio);
                if (fondosDisponiblesSocio != null) {
                    textBoxFondosAniadirFactura.Text = "$ " + fondosDisponiblesSocio;
                }
            }
        }

        private void comboBoxSocioFondosDisponibles_SelectedIndexChanged(object sender, EventArgs e) {
            ConsultarFondosDisponiblesSocio();
        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e) {

        }

        private void botonAniadirFacturaPersonaAutorizada_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelSocioAniadirFacturaPersonaAu.Visible = true;
            comboBoxSocioRAniadirFacturaPersonaA.Items.Clear();

            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioRAniadirFacturaPersonaA.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void botonVerPagarFacturasPersonaAutorizada_Click(object sender, EventArgs e) {
            ocultarPaneles();
            panelListarFacturaPersonaA.Visible = true;
            textBoxFondosListarFacturaPersonaA.Text = "";

            comboBoxSocioRListarFacturaPersonaA.Items.Clear();
            comboBoxPersonaAListarFacturaPersonaA.Items.Clear();

            List<List<String>> listaSocios = clubSocial.VerSocios();
            foreach (List<String> filaListaSocios in listaSocios) {
                comboBoxSocioRListarFacturaPersonaA.Items.Add("(" + filaListaSocios[0] + ") " + filaListaSocios[1]);
            }
        }

        private void comboBoxSocioRListarFacturaPersonaA_SelectedIndexChanged(object sender, EventArgs e) {
            comboBoxPersonaAListarFacturaPersonaA.Items.Clear();

            String cedulaSocioRCadena = comboBoxSocioRListarFacturaPersonaA.Text;
            if (!cedulaSocioRCadena.Equals("")) {
                int cedulaSocioR = Int32.Parse(cedulaSocioRCadena.Split(")")[0].Replace("(", ""));
                List<List<String>> listaPersonasA = clubSocial.VerPersonasAutorizadasSocio(cedulaSocioR);
                foreach (List<String> filaListaPersonasA in listaPersonasA) {
                    comboBoxPersonaAListarFacturaPersonaA.Items.Add("(" + filaListaPersonasA[0] + ") " + filaListaPersonasA[1]);
                }
                String fondosDisponiblesSocio = clubSocial.VerFondosDisponiblesSocio(cedulaSocioR);
                if (fondosDisponiblesSocio != null) {
                    textBoxFondosListarFacturaPersonaA.Text = "$ " + fondosDisponiblesSocio;
                }
            } else MessageBox.Show("Error, debe seleccionar un socio.");
        }

        private void comboBoxPersonaAListarFacturaPersonaA_SelectedIndexChanged(object sender, EventArgs e) {
            crearFilasTablaListarFacturaPersonaA();
        }

        private void comboBoxListarFacturaSocio_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void botonPagarListarFacturaPersonaA_Click(object sender, EventArgs e) {
            String cedulaPersonaACadena = comboBoxPersonaAListarFacturaPersonaA.Text;
            if (!cedulaPersonaACadena.Equals("")) {
                int cedulaPersonaA = Int32.Parse(cedulaPersonaACadena.Split(")")[0].Replace("(", ""));
                if (clubSocial.PagarFacturasPersonaAutorizada(cedulaPersonaA)) {
                    crearFilasTablaListarFacturaPersonaA();
                    int cedulaSocio = Int32.Parse(comboBoxSocioRListarFacturaPersonaA.Text.Split(")")[0].Replace("(", ""));
                    String fondosDisponiblesSocio = clubSocial.VerFondosDisponiblesSocio(cedulaSocio);
                    if (fondosDisponiblesSocio != null) {
                        textBoxFondosListarFacturaPersonaA.Text = "$ " + fondosDisponiblesSocio;
                    }
                }
            } else MessageBox.Show("Error, debe seleccionar una persona autorizada.");
        }

        private void textBoxFondosAniadirFactura_TextChanged(object sender, EventArgs e) {

        }

        private void labelFondosAniadirFactura_Click(object sender, EventArgs e) {

        }

        private void label15_Click(object sender, EventArgs e) {

        }

        private void label17_Click(object sender, EventArgs e) {

        }

        private void comboBoxCategoriaAniadirFactura_SelectedIndexChanged(object sender, EventArgs e) {
            comboBoxProductoAniadirFactura.Items.Clear();
            comboBoxAdicionAniadirFacturaSocio.Items.Clear();
            tablaIngredientesAniadirFacturaSocio.Rows.Clear();
            tablaAdicionesAniadirFacturaSocio.Rows.Clear();
            comboBoxAdicionAniadirFacturaSocio.Enabled = false;
            textBoxValorAniadirFactura.Text = "";
            switch (comboBoxCategoriaAniadirFactura.Text) {
                case "Entrada": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = true;
                        comboBoxProductoAniadirFactura.Items.Add("Papas con queso cheddar y tocineta");
                        comboBoxProductoAniadirFactura.Items.Add("Empanadas de arroz y carne (5)");
                        comboBoxProductoAniadirFactura.Items.Add("Patacones con hogao (5)");
                        labelAdicionAniadirFacturaSocio.Text = "Salsas";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Salsa tartara");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Salsa de la casa");
                        break;
                    }
                case "Postre": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = true;
                        comboBoxProductoAniadirFactura.Items.Add("Tres leches");
                        comboBoxProductoAniadirFactura.Items.Add("Milo");
                        comboBoxProductoAniadirFactura.Items.Add("Oreo");
                        labelAdicionAniadirFacturaSocio.Text = "Endulzante";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Salsa de chocolate");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Lecherita");
                        break;
                    }
                case "Plato fuerte mixto": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = true;
                        comboBoxProductoAniadirFactura.Items.Add("Punta de anca");
                        comboBoxProductoAniadirFactura.Items.Add("Pollito a la plancha");
                        comboBoxProductoAniadirFactura.Items.Add("Trucha");
                        labelAdicionAniadirFacturaSocio.Text = "Salsas";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Salsa tartara");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Salsa de la casa");
                        break;
                    }
                case "Plato fuerte vegano": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = true;
                        comboBoxProductoAniadirFactura.Items.Add("Pizza vegana (6 porciones)");
                        comboBoxProductoAniadirFactura.Items.Add("Pasta vegana");
                        comboBoxProductoAniadirFactura.Items.Add("Ensaladita");
                        labelAdicionAniadirFacturaSocio.Text = "Adiciones";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Oregano (25 g) - $ 100");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Sal de ajo (25 g) - $ 200");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Papas (500 g) - $ 2000");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Arroz (200 g) - $ 3500");
                        break;
                    }
                case "Bebida fria alcoholica": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = false;
                        comboBoxProductoAniadirFactura.Items.Add("Crema de whisky (700 ml)[Baileys]");
                        comboBoxProductoAniadirFactura.Items.Add("Guarito barato (2000 ml)[Aguardiente Antioqueño]");
                        comboBoxProductoAniadirFactura.Items.Add("Limoncito con ron (750 ml)[Ron viejo de Caldas]");
                        labelAdicionAniadirFacturaSocio.Text = "Grado de alcohol";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("5°");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("10°");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("20°");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("30°");
                        comboBoxAdicionAniadirFacturaSocio.SelectedItem = "5°";
                        break;
                    }
                case "Bebida fria no alcoholica": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = false;
                        comboBoxProductoAniadirFactura.Items.Add("Milito (500 ml)[Nestle]");
                        comboBoxProductoAniadirFactura.Items.Add("Jugo de naranja (500 ml)[Frutiño]");
                        comboBoxProductoAniadirFactura.Items.Add("Avena (500 ml)[Alpina]");
                        labelAdicionAniadirFacturaSocio.Text = "Gramaje de azucar";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("2g");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("5g");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("10g");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("15g");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("20g");
                        comboBoxAdicionAniadirFacturaSocio.SelectedItem = "2g";
                        break;
                    }
                case "Bebida caliente": {
                        botonAgregarAdicionAniadirFacturaSocio.Enabled = true;
                        comboBoxProductoAniadirFactura.Items.Add("Cafe (200 ml)");
                        comboBoxProductoAniadirFactura.Items.Add("Chocolate (350 ml)");
                        comboBoxProductoAniadirFactura.Items.Add("Milito (500 ml)");
                        labelAdicionAniadirFacturaSocio.Text = "Adiciones";
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Azucar(10 g) - $ 300");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Queso (20 g) - $ 1000");
                        comboBoxAdicionAniadirFacturaSocio.Items.Add("Pan (200 g) - $ 800");
                        break;
                    }
            }
        }

        private void botonAgregarAdicionAniadirFacturaSocio_Click(object sender, EventArgs e) {
            if (!comboBoxAdicionAniadirFacturaSocio.Text.Equals("")) {
                tablaAdicionesAniadirFacturaSocio.Rows.Add(tablaAdicionesAniadirFacturaSocio.Rows.Count, comboBoxAdicionAniadirFacturaSocio.Text);
                if (comboBoxCategoriaAniadirFactura.Text.Equals("Plato fuerte vegano") || comboBoxCategoriaAniadirFactura.Text.Equals("Bebida caliente")) textBoxValorAniadirFactura.Text = "$ " + (Int32.Parse(textBoxValorAniadirFactura.Text.Replace("$", "").Replace(" ", "")) + Int32.Parse(comboBoxAdicionAniadirFacturaSocio.Text.Split("-")[1].Replace("$", "").Replace(" ", ""))).ToString(); 
            } else MessageBox.Show("Debe seleccionar " + labelAdicionAniadirFacturaSocio.Text);
        }

        private void botonComboBoxAceptarBebiba_Click(object sender, EventArgs e) {
            if (!comboBoxBebidaFria.Text.Equals("") && !comboBoxGramajeAzucar.Text.Equals("")) {
                panelComboBoxBebida.Visible = false;
                if (panelAniadirFacturaPersonaAu.Visible) {
                    panelAniadirFacturaPersonaAu.Enabled = true;
                } else panelAniadirFacturaSocio.Enabled = true;
            } else MessageBox.Show("Error, debe seleccionar una bebida y un gramaje de azucar.");
        }

        private void label18_Click(object sender, EventArgs e) {

        }

        private void comboBoxAdicionAniadirFacturaSocio_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void botonAceptarSocioAniadirFacturaPersonaA_Click(object sender, EventArgs e) {
            if (!comboBoxSocioRAniadirFacturaPersonaA.Text.Equals("")) {
                panelSocioAniadirFacturaPersonaAu.Visible = false;
                panelAniadirFacturaPersonaAu.Visible = true;

                tablaAdicionesAniadirFacturaPersonaA.Rows.Clear();
                tablaIngredientesAniadirFacturaPersonaA.Rows.Clear();

                comboBoxPersonaAAniadirFactura.Items.Clear();
                textBoxFondosAniadirFacturaPA.Text = "";
                textBoxValorAniadirFacturaPA.Text = "";
                comboBoxCategoriaAniadirFacturaPA.SelectedIndex = -1;

                List<List<String>> listaPersonasAutorizadas = clubSocial.VerPersonasAutorizadasSocio(Int32.Parse(comboBoxSocioRAniadirFacturaPersonaA.Text.Split(")")[0].Replace("(", "")));
                foreach (List<String> filaListaPersonasAutorizadas in listaPersonasAutorizadas) {
                    comboBoxPersonaAAniadirFactura.Items.Add("(" + filaListaPersonasAutorizadas[0] + ") " + filaListaPersonasAutorizadas[1]);
                }
            } else MessageBox.Show("Error, debe seleccionar una persona autorizada.");
        }

        private void panelAniadirFacturaPersonaAu_Paint(object sender, PaintEventArgs e) {

        }

        private void panelSocioAniadirFacturaPersonaA_Paint(object sender, PaintEventArgs e) {

        }

        private void comboBoxPersonaAAniadirFactura_SelectedIndexChanged(object sender, EventArgs e) {
            String cedulaPersonaAutorizadaCadena = comboBoxPersonaAAniadirFactura.Text;
            if (!cedulaPersonaAutorizadaCadena.Equals("")) {
                int cedulaPersonaAutorizada = Int32.Parse(cedulaPersonaAutorizadaCadena.Split(")")[0].Replace("(", ""));
                String fondosDisponiblesPersonaAutorizada = clubSocial.BuscarPersonaAutorizadaPorCedula(cedulaPersonaAutorizada).SocioResponsable.FondosDisponiblesSocio.ToString();
                if (fondosDisponiblesPersonaAutorizada != null) {
                    textBoxFondosAniadirFacturaPA.Text = "$ " + fondosDisponiblesPersonaAutorizada;
                }
            }     
        }

        private void comboBoxCategoriaAniadirFacturaPA_SelectedIndexChanged(object sender, EventArgs e) {
            comboBoxProductoAniadirFacturaPA.Items.Clear();
            comboBoxAdicionAniadirFacturaPA.Items.Clear();
            tablaIngredientesAniadirFacturaPersonaA.Rows.Clear();
            tablaAdicionesAniadirFacturaPersonaA.Rows.Clear();
            comboBoxAdicionAniadirFacturaPA.Enabled = false;
            textBoxValorAniadirFacturaPA.Text = "";
            switch (comboBoxCategoriaAniadirFacturaPA.Text) {
                case "Entrada": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = true;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Papas con queso cheddar y tocineta");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Empanadas de arroz y carne (5)");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Patacones con hogao (5)");
                        labelAdicionAniadirFacturaPA.Text = "Salsas";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Salsa tartara");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Salsa de la casa");
                        break;
                    }
                case "Postre": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = true;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Tres leches");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Milo");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Oreo");
                        labelAdicionAniadirFacturaPA.Text = "Endulzante";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Salsa de chocolate");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Lecherita");
                        break;
                    }
                case "Plato fuerte mixto": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = true;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Punta de anca");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Pollito a la plancha");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Trucha");
                        labelAdicionAniadirFacturaPA.Text = "Salsas";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Salsa tartara");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Salsa de la casa");
                        break;
                    }
                case "Plato fuerte vegano": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = true;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Pizza vegana (6 porciones)");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Pasta vegana");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Ensaladita");
                        labelAdicionAniadirFacturaPA.Text = "Adiciones";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Oregano (25 g) - $ 100");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Sal de ajo (25 g) - $ 200");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Papas (500 g) - $ 2000");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Arroz (200 g) - $ 3500");
                        break;
                    }
                case "Bebida fria alcoholica": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = false;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Crema de whisky (700 ml)[Baileys]");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Guarito barato (2000 ml)[Aguardiente Antioqueño]");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Limoncito con ron (750 ml)[Ron viejo de Caldas]");
                        labelAdicionAniadirFacturaPA.Text = "Grado de alcohol";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("5°");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("10°");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("20°");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("30°");
                        comboBoxAdicionAniadirFacturaPA.SelectedItem = "5°";
                        break;
                    }
                case "Bebida fria no alcoholica": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = false;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Milito (500 ml)[Nestle]");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Jugo de naranja (500 ml)[Frutiño]");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Avena (500 ml)[Alpina]");
                        labelAdicionAniadirFacturaPA.Text = "Gramaje de azucar";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("2g");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("5g");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("10g");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("15g");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("20g");
                        comboBoxAdicionAniadirFacturaPA.SelectedItem = "2g";
                        break;
                    }
                case "Bebida caliente": {
                        botonAgregarAdicionAniadirFacturaPA.Enabled = true;
                        comboBoxProductoAniadirFacturaPA.Items.Add("Cafe (200 ml)");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Chocolate (350 ml)");
                        comboBoxProductoAniadirFacturaPA.Items.Add("Milito (500 ml)");
                        labelAdicionAniadirFacturaPA.Text = "Adiciones";
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Azucar(10 g) - $ 300");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Queso (20 g) - $ 1000");
                        comboBoxAdicionAniadirFacturaPA.Items.Add("Pan (200 g) - $ 800");
                        break;
                    }
            }
        }

        private void comboBoxProductoAniadirFacturaPA_SelectedIndexChanged(object sender, EventArgs e) {
            tablaIngredientesAniadirFacturaPersonaA.Rows.Clear();
            tablaAdicionesAniadirFacturaPersonaA.Rows.Clear();
            comboBoxAdicionAniadirFacturaPA.Enabled = true;
            switch (comboBoxProductoAniadirFacturaPA.Text) {
                case "Papas con queso cheddar y tocineta": {
                        textBoxValorAniadirFacturaPA.Text = "$ 15000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Queso cheddar");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Tocineta");
                        break;
                    }
                case "Empanadas de arroz y carne (5)": {
                        textBoxValorAniadirFacturaPA.Text = "$ 10000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Masa de maiz");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Arroz");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Carne");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Guiso");
                        break;
                    }
                case "Patacones con hogao (5)": {
                        textBoxValorAniadirFacturaPA.Text = "$ 5000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Platano verde");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Hogao");
                        break;
                    }
                case "Tres leches": {
                        textBoxValorAniadirFacturaPA.Text = "$ 8000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche en polvo");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Lecherita");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Galleta sultan");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Gelatina sin sabor");
                        break;
                    }
                case "Milo": {
                        textBoxValorAniadirFacturaPA.Text = "$ 9000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Milo");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Nuggets milo");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Gelatina sin sabor");
                        break;
                    }
                case "Oreo": {
                        textBoxValorAniadirFacturaPA.Text = "$ 9000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Galleta oreo");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Gelatina sin sabor");
                        break;
                    }
                case "Punta de anca": {
                        textBoxValorAniadirFacturaPA.Text = "$ 30000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Ensalada de lechuga y tomate");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Arepa con queso mazarella");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Carne punta de anca");
                        panelAniadirFacturaPersonaAu.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Pollito a la plancha": {
                        textBoxValorAniadirFacturaPA.Text = "$ 26000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Pechuga de pollo");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Ensalada de lechuga y tomate");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Arepa con queso mazarella");
                        panelAniadirFacturaPersonaAu.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Trucha": {
                        textBoxValorAniadirFacturaPA.Text = "$ 28000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Papas a la francesa");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Ensalada de lechuga y tomate");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Arepa con queso mazarella");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Trucha");
                        panelAniadirFacturaPersonaAu.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Pizza vegana (6 porciones)": {
                        textBoxValorAniadirFacturaPA.Text = "$ 21000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Masa de pizza");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Lechuga");
                        panelAniadirFacturaPersonaAu.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Pasta vegana": {
                        textBoxValorAniadirFacturaPA.Text = "$ 20000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Pasta");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Lechuga");
                        panelAniadirFacturaPersonaAu.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Ensaladita": {
                        textBoxValorAniadirFacturaPA.Text = "$ 16000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Lechuga");
                        panelAniadirFacturaPersonaAu.Enabled = false;
                        panelComboBoxBebida.Visible = true;
                        panelComboBoxBebida.BringToFront();
                        break;
                    }
                case "Crema de whisky (700 ml)[Baileys]": {
                        textBoxValorAniadirFacturaPA.Text = "$ 80000";
                        break;
                    }
                case "Guarito barato (2000 ml)[Aguardiente Antioqueño]": {
                        textBoxValorAniadirFacturaPA.Text = "$ 100000";
                        break;
                    }
                case "Limoncito con ron (750 ml)[Ron viejo de Caldas]": {
                        textBoxValorAniadirFacturaPA.Text = "$ 50000";
                        break;
                    }
                case "Milito (500 ml)[Nestle]": {
                        textBoxValorAniadirFacturaPA.Text = "$ 4000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Milo");
                        break;
                    }
                case "Jugo de naranja (500 ml)[Frutiño]": {
                        textBoxValorAniadirFacturaPA.Text = "$ 3000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Agua");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Naranja");
                        break;
                    }
                case "Avena (500 ml)[Alpina]": {
                        textBoxValorAniadirFacturaPA.Text = "$ 2500";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Avena");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Azucar");
                        break;
                    }
                case "Cafe (200 ml)": {
                        textBoxValorAniadirFacturaPA.Text = "$ 2000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Agua o leche");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Cafe");
                        break;
                    }
                case "Chocolate (350 ml)": {
                        textBoxValorAniadirFacturaPA.Text = "$ 2500";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "AguaPanela");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Chocolate");
                        break;
                    }
                case "Milito (500 ml)": {
                        textBoxValorAniadirFacturaPA.Text = "$ 4000";
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Leche entera");
                        tablaIngredientesAniadirFacturaPersonaA.Rows.Add(tablaIngredientesAniadirFacturaPersonaA.Rows.Count, "Milo");
                        break;
                    }
                default: {
                        textBoxValorAniadirFacturaPA.Text = "0";
                        break;
                    }
            }
        }

        private void botonAgregarAdicionAniadirFacturaPA_Click(object sender, EventArgs e) {
            if (!comboBoxAdicionAniadirFacturaPA.Text.Equals("")) {
                tablaAdicionesAniadirFacturaPersonaA.Rows.Add(tablaAdicionesAniadirFacturaPersonaA.Rows.Count, comboBoxAdicionAniadirFacturaPA.Text);
                if (comboBoxCategoriaAniadirFacturaPA.Text.Equals("Plato fuerte vegano") || comboBoxCategoriaAniadirFacturaPA.Text.Equals("Bebida caliente")) textBoxValorAniadirFacturaPA.Text = "$ " + (Int32.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$", "").Replace(" ", "")) + Int32.Parse(comboBoxAdicionAniadirFacturaPA.Text.Split("-")[1].Replace("$", "").Replace(" ", ""))).ToString();
            } else MessageBox.Show("Debe seleccionar " + labelAdicionAniadirFacturaPA.Text);
        }

        private void button3_Click_1(object sender, EventArgs e) {
            panelAniadirFacturaPersonaAu.Visible = false;
        }

        private void button2_Click_2(object sender, EventArgs e) {
            String cedulaPersonaACadena = comboBoxPersonaAAniadirFactura.Text;
            if (!cedulaPersonaACadena.Equals("")) {
                String ingredientes = "";
                Consumo consumo = null;
                int cedulaPersonaA = Int32.Parse(cedulaPersonaACadena.Split(")")[0].Replace("(", ""));
                float valorFactura = float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$", "").Replace(" ", "").Replace(".", ""));
                switch (comboBoxCategoriaAniadirFacturaPA.Text) {
                    case "Entrada": {
                            List<String> listaSalsas = new List<String>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaPersonaA.Rows.Count; i++) {
                                listaSalsas.Add(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString());
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaPersonaA.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString();
                                if (i != tablaIngredientesAniadirFacturaPersonaA.Rows.Count - 1) ingredientes += ", ";
                            }
                            consumo = new EntradaPlato(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], ingredientes, true, listaSalsas);
                            MessageBox.Show(consumo.NombreConsumo);
                            break;
                        }
                    case "Postre": {
                            List<String> listaEndulzantes = new List<String>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaPersonaA.Rows.Count; i++) {
                                listaEndulzantes.Add(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString());
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaPersonaA.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString();
                                if (i != tablaIngredientesAniadirFacturaPersonaA.Rows.Count - 1) ingredientes += ", ";
                            }
                            consumo = new PostrePlato(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], ingredientes, listaEndulzantes);
                            break;
                        }
                    case "Plato fuerte mixto": {
                            String bebida = comboBoxBebidaFria.Text;
                            int gramajeAzucar = Int32.Parse(comboBoxGramajeAzucar.Text.Replace("g", ""));
                            List<String> listaSalsas = new List<String>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaPersonaA.Rows.Count; i++) {
                                listaSalsas.Add(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString());
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaPersonaA.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString;
                                if (i != tablaIngredientesAniadirFacturaPersonaA.Rows.Count - 1) ingredientes += ", ";
                            }
                            NoAlcoholicaFriaBebida bebidaFriaNoAlcoholica =
                                new NoAlcoholicaFriaBebida(bebida.Split("(")[0], 0.0, comboBoxPersonaAAniadirFactura.Text.Split(")")[1], Int32.Parse(bebida.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", "")),
                                bebida.Split("[")[1].Replace("]", ""), gramajeAzucar);
                            consumo = new MixtoFuertePlato(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], ingredientes, bebidaFriaNoAlcoholica, listaSalsas);
                            break;
                        }
                    case "Plato fuerte vegano": {
                            String bebida = comboBoxBebidaFria.Text;
                            int gramajeAzucar = Int32.Parse(comboBoxGramajeAzucar.Text.Replace("g", ""));
                            Dictionary<String, double> diccionarioAdiciones = new Dictionary<String, double>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaPersonaA.Rows.Count; i++) {
                                diccionarioAdiciones.Add(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString().Split(" -")[0],
                                    double.Parse(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString().Split(" -")[1].Replace(" $ ", "")));
                            }
                            for (int i = 0; i < tablaIngredientesAniadirFacturaPersonaA.Rows.Count; i++) {
                                ingredientes += tablaIngredientesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString();
                                if (i != tablaIngredientesAniadirFacturaPersonaA.Rows.Count - 1) ingredientes += ", ";
                            }
                            NoAlcoholicaFriaBebida bebidaFriaNoAlcoholica =
                                new NoAlcoholicaFriaBebida(bebida.Split("(")[0], 0.0, comboBoxPersonaAAniadirFactura.Text.Split(")")[1], Int32.Parse(bebida.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", "")),
                                bebida.Split("[")[1].Replace("]", ""), gramajeAzucar);
                            consumo = new VeganoFuertePlato(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], ingredientes, bebidaFriaNoAlcoholica, diccionarioAdiciones);
                            break;
                        }
                    case "Bebida fria alcoholica": {
                            String marcaBebida = comboBoxProductoAniadirFacturaPA.Text.Split("[")[1].Replace("]", "");
                            int tamanio = Int32.Parse(comboBoxProductoAniadirFacturaPA.Text.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", ""));
                            int gradoAlcohol = Int32.Parse(comboBoxAdicionAniadirFacturaPA.Text.Replace("°", ""));
                            consumo = new AlcoholicaFriaBebida(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], tamanio, marcaBebida, gradoAlcohol);
                            break;
                        }
                    case "Bebida fria no alcoholica": {
                            String marcaBebida = comboBoxProductoAniadirFacturaPA.Text.Split("[")[1].Replace("]", "");
                            int tamanio = Int32.Parse(comboBoxProductoAniadirFacturaPA.Text.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", ""));
                            int gramajeAzucar = Int32.Parse(comboBoxAdicionAniadirFacturaPA.Text.Replace("g", ""));
                            consumo = new NoAlcoholicaFriaBebida(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], tamanio, marcaBebida, gramajeAzucar);
                            break;
                        }
                    case "Bebida caliente": {
                            int tamanio = Int32.Parse(comboBoxProductoAniadirFacturaPA.Text.Split("(")[1].Split("[")[0].Replace(")", "").Replace(" ml", ""));
                            Dictionary<String, double> diccionarioAdiciones = new Dictionary<String, double>();
                            for (int i = 0; i < tablaAdicionesAniadirFacturaPersonaA.Rows.Count; i++) {
                                diccionarioAdiciones.Add(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString().Split(" -")[0],
                                    double.Parse(tablaAdicionesAniadirFacturaPersonaA.Rows[i].Cells[1].Value.ToString().Split(" -")[1].Replace(" $ ", "")));
                            }
                            consumo = new CalienteBebida(comboBoxProductoAniadirFacturaPA.Text, float.Parse(textBoxValorAniadirFacturaPA.Text.Replace("$ ", "")), comboBoxPersonaAAniadirFactura.Text.Split(")")[1], tamanio, diccionarioAdiciones);
                            break;
                        }
                }
                clubSocial.RegistarFacturaAPersonaAutorizada(consumo, cedulaPersonaA);
            } else {
                MessageBox.Show("Error, debe seleccionar un PersonaA.");
            }
        }
    }
}