using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialCSharpGUI.Code {
    internal class FuertePlato : Plato {
        public FriaBebida bebidaFriaPlatoFuerte;

        public FuertePlato(String nombreConsumo, double precioConsumo, String nombreResponsableConsumo, String ingredientes, FriaBebida bebidaFriaPlatoFuerte) : base(nombreConsumo, precioConsumo, nombreResponsableConsumo, ingredientes) {
            this.bebidaFriaPlatoFuerte = bebidaFriaPlatoFuerte;
        }

        public FriaBebida BebidaFriaPlatoFuerte { get => bebidaFriaPlatoFuerte; set => bebidaFriaPlatoFuerte = value; }
    }
}
