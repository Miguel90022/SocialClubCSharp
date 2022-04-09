using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class MixtoFuertePlato : FuertePlato {
        public List<String> listaDeSalsas;
        
        public MixtoFuertePlato(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, String ingredientes, FriaBebida bebidaFria, List<String> listaDeSalsas) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, ingredientes, bebidaFria) {
            this.listaDeSalsas = listaDeSalsas;
        }

        public List<String> ListaDeSalsas { get => listaDeSalsas; set => listaDeSalsas = value; }
    }
}
