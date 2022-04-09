namespace ClubSocialCSharpGUI.Code {
    internal class Socio {
        //Atributos
        private String tipoDeSuscripcionSocio;
        private int cedulaSocio;
        private double fondosDisponiblesSocio;
        private String nombreSocio;
        private Consumo[] consumosSocio;
        private PersonaAutorizada[] personasAutorizadasSocio;

        public Socio(string tipoDeSuscripcionSocio, int cedulaSocio, double fondosDisponiblesSocio, String nombreSocio) {
            this.tipoDeSuscripcionSocio = tipoDeSuscripcionSocio;
            this.cedulaSocio = cedulaSocio;
            this.fondosDisponiblesSocio = fondosDisponiblesSocio;
            this.nombreSocio = nombreSocio;
            this.consumosSocio = new Consumo[20];
            this.personasAutorizadasSocio = new PersonaAutorizada[10];
        }

        public String TipoDeSuscipcionSocio { get => tipoDeSuscripcionSocio; set => tipoDeSuscripcionSocio = value; }

        public int CedulaSocio { get => cedulaSocio; set => cedulaSocio = value; }

        public double FondosDisponiblesSocio { get => fondosDisponiblesSocio; set => fondosDisponiblesSocio = value; }

        public String NombreSocio { get => nombreSocio; set => nombreSocio = value; }

        public Consumo[] ConsumosSocio { get => consumosSocio; set => consumosSocio = value; }

        public PersonaAutorizada[] PersonasAutorizadasSocio { get => personasAutorizadasSocio; set => personasAutorizadasSocio = value; }
    }
}
