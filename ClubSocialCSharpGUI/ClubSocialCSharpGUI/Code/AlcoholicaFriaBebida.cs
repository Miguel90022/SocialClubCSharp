using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class AlcoholicaFriaBebida : FriaBebida {
        public double gradoAlcoholBebida;

        public AlcoholicaFriaBebida (String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, int tamanio, String marca, double gradoAlcoholBebida) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, tamanio, marca) {
            this.gradoAlcoholBebida = gradoAlcoholBebida;
        }

        public double GradoAlcoholBebida { get => gradoAlcoholBebida; set => gradoAlcoholBebida = value;  }
    }
}
