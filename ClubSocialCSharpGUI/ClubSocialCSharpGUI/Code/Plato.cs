namespace ClubSocialCSharpGUI.Code {
    internal class Plato : Consumo {
        public String ingredientesPlato;

        public Plato(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, String ingredientesPlato) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo) {
            this.ingredientesPlato = ingredientesPlato;
        }

        public String IngredientesPlato { get => ingredientesPlato; set => ingredientesPlato = value; }
    }
}
