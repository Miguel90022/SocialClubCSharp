namespace ClubSocialCSharpGUI.Code {
    internal class PersonaAutorizada {
        private String nombrePersonaAutorizada;
        private Socio socioResponsable;
        private int cedulaPersonaAutorizada;
        private PilaConsumos consumosPersonaAutorizada;

        public PersonaAutorizada(String nombrePersonaAutorizada, Socio socioResponsable, int cedulaPersonaAutorizada) {
            this.nombrePersonaAutorizada = nombrePersonaAutorizada;
            this.socioResponsable = socioResponsable;
            this.cedulaPersonaAutorizada = cedulaPersonaAutorizada;
            consumosPersonaAutorizada = new PilaConsumos();
        }

        public String NombrePersonaAutorizada { get => nombrePersonaAutorizada; set => nombrePersonaAutorizada = value; }

        public Socio SocioResponsable { get => socioResponsable; set => socioResponsable = value; }

        public int CedulaPersonaAutorizada { get => cedulaPersonaAutorizada; set => cedulaPersonaAutorizada = value; }

        public PilaConsumos FacturasPersonaAutorizada { get => consumosPersonaAutorizada; set => consumosPersonaAutorizada = value; }
    }
}
