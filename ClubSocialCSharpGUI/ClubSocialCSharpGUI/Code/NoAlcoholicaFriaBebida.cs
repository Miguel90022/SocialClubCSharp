using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class NoAlcoholicaFriaBebida : FriaBebida{
        public int gramajeDeAzucarBebida;

        public NoAlcoholicaFriaBebida(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, int tamanio, String marca, int gramajeDeAzucaBebida) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, tamanio, marca) {
            this.gramajeDeAzucarBebida = gramajeDeAzucaBebida;
        }

        public int GramajeDeAzucarBebida { get => gramajeDeAzucarBebida; set => gramajeDeAzucarBebida = value; }
    }
}
