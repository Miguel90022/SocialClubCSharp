namespace ClubSocialCSharpGUI.Code {
    internal class Consumo {
        private String nombreConsumo;
        private double precioConsumo;
        private String nombreResponsableConsumo;

        public Consumo(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo) {
            this.nombreConsumo = nombreConsumo;
            this.precioConsumo = precioConsumo;
            this.nombreResponsableConsumo = nombreResponsableConsumo;
        }

        public String NombreConsumo { get => nombreConsumo; set => nombreConsumo = value; }

        public double PrecioConsumo { get => precioConsumo; set => precioConsumo = value; }

        public String NombreResponsableFactura { get => nombreResponsableConsumo; set => nombreResponsableConsumo = value; }
    }
}
