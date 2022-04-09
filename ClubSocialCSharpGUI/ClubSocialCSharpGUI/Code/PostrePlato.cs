using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class PostrePlato : Plato {
        public List<String> listaEndulzantes;

        public PostrePlato(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, String ingredientes, List<String> listaEndulzantes) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, ingredientes) {
            this.listaEndulzantes = listaEndulzantes;
        }

        public List<String> ListaEndulzantes { get => listaEndulzantes; set => listaEndulzantes = value; }
    }
}
