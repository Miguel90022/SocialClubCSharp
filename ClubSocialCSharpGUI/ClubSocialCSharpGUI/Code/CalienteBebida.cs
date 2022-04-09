using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class CalienteBebida : Bebida {
        Dictionary<String, double> listaDeAdicionesBebidaCaliente;

        public CalienteBebida(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, int tamanioBebida, Dictionary<String, double> listaDeAdicionesBebidaCaliente) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, tamanioBebida) {
            this.listaDeAdicionesBebidaCaliente = listaDeAdicionesBebidaCaliente;
        }

        public Dictionary<String, double> ListaDeAdicionesBebidaCaliente { get => listaDeAdicionesBebidaCaliente; set => listaDeAdicionesBebidaCaliente = value; }    
    }
}
