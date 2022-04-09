namespace ClubSocialCSharpGUI.Code {
    internal class Bebida : Consumo {
        public int tamanioBebida;

        public Bebida(String nombre, double precio, String nombreResponsableConsumo, int tamanioBebida) : base(nombre, precio, nombreResponsableConsumo) {
            this.tamanioBebida = tamanioBebida;
        }

        public int TamanioBebida { get => tamanioBebida; set => tamanioBebida = value; }
    }
}
