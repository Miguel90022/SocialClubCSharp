using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class FriaBebida : Bebida {
        public String marca;

        public FriaBebida(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, int tamanio, String marca) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, tamanio) {
            this.marca = marca;
        }

        public String Marca { get => marca; set => marca = value; }
    }
}
