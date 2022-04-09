namespace ClubSocialCSharpGUI.Code {
    internal class EntradaPlato : Plato {
        public bool entradaCompartida;
        public List<String> listaSalsas;

        public EntradaPlato(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, String ingredientes, bool entradaCompartida, List<String> listaSalsas) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, ingredientes) {
            this.entradaCompartida = entradaCompartida;
            this.listaSalsas = listaSalsas;
        }

        public bool EntradaCompartida { get => entradaCompartida; set => entradaCompartida = value; }

        public List<String> ListaSalsas { get => listaSalsas; set => listaSalsas = value; }
    }
}
