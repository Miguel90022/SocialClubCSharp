namespace ClubSocialCSharpGUI.Code {
    internal class NodoConsumo {
        private Consumo consumo;
        private NodoConsumo siguiente;

        public NodoConsumo(Consumo consumo) {
            this.consumo = consumo;
            this.siguiente = null;
        }

        public Consumo Consumo { get => consumo; set => consumo = value; }

        public NodoConsumo Siguiente { get => siguiente; set => siguiente = value; }
    }
}
