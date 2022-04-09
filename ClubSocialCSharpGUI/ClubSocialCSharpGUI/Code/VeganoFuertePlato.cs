using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class VeganoFuertePlato : FuertePlato {
        public Dictionary<String, double> listaDeAdiciones;

        public VeganoFuertePlato(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, String ingredientes, FriaBebida bebidaFria, Dictionary<String, double> listaDeAdiciones) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, ingredientes, bebidaFria) {
            this.listaDeAdiciones = listaDeAdiciones;
        }

        public Dictionary<String, double> ListaDeAdiciones { get => listaDeAdiciones; set => listaDeAdiciones = value;}
    }
}
