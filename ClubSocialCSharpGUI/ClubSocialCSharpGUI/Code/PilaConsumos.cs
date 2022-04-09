namespace ClubSocialCSharpGUI.Code {
    internal class PilaConsumos {
        private NodoConsumo cima;

        public PilaConsumos() {
            this.cima = null;
        }

        public NodoConsumo Cima { get => cima; set => cima = value; }

        public bool PilaVacia() {
            return cima == null;
        }

        public void PushNodo(Consumo consumo) {
            NodoConsumo nuevo = new NodoConsumo(consumo);
            if (PilaVacia()) {
                cima = nuevo;
            } else {
                nuevo.Siguiente = cima;
                cima = nuevo;
            }
        }

        public NodoConsumo Peek() {
            return cima;
        }

        public void PopNodo() {
            if (!PilaVacia()) {
                cima = cima.Siguiente;
            }
        }
    }
}
