namespace ClubSocialCSharpGUI.Code {
    internal class ClubSocial {
        private Socio[] sociosVIP;
        private Socio[] sociosRegulares;

        public ClubSocial() {
            this.sociosVIP = new Socio[3];
            this.sociosRegulares = new Socio[32];
        }

        public Socio[] SociosVIP { get => sociosVIP; set => sociosVIP = value; }

        public Socio[] SociosRegulares { get => sociosRegulares; set => sociosRegulares = value; }

        public PersonaAutorizada BuscarPersonaAutorizadaPorCedula(int cedula) {
            for (int i = 0; i < sociosVIP.Length; i++) {
                if (sociosVIP[i] != null) {
                    foreach (PersonaAutorizada personaAutorizada in sociosVIP[i].PersonasAutorizadasSocio) {
                        if (personaAutorizada != null && personaAutorizada.CedulaPersonaAutorizada == cedula) return personaAutorizada;
                    }
                }
            }
            for (int i = 0; i < sociosRegulares.Length; i++) {
                if (sociosRegulares[i] != null) {
                    foreach (PersonaAutorizada personaAutorizada in sociosRegulares[i].PersonasAutorizadasSocio) {
                        if (personaAutorizada != null && personaAutorizada.CedulaPersonaAutorizada == cedula) return personaAutorizada;
                    }
                }
            }
            return null;
        }

        public Socio BuscarSocioPorCedula(int cedulaSocio) {
            Socio encontrado = null;
            for (int i = 0; i < sociosVIP.Length; i++) {
                if (sociosVIP[i] != null && sociosVIP[i].CedulaSocio == cedulaSocio) {
                    encontrado = sociosVIP[i];
                    break;
                }
            }
            for (int i = 0; i < sociosRegulares.Length; i++) {
                if (sociosRegulares[i] != null && sociosRegulares[i].CedulaSocio == cedulaSocio) {
                    encontrado = sociosRegulares[i];
                    break;
                }
            }
            return encontrado;
        }

        public bool CuposVIP() {
            for (int i = 0; i < sociosVIP.Length; i++) {
                if (sociosVIP[i] == null) return true;
            }
            return false;
        }

        public bool CuposRegulares() {
            for (int i = 0; i < sociosRegulares.Length; i++) {
                if (sociosRegulares[i] == null) return true;
            }
            return false;
        }

        public bool AfiliarSocio(String cedulaSocioRecibida, String nombreSocio, String tipoSuscripcion) {
            bool cedulaEsNumero;
            int cedulaSocio = 0;
            bool registrado = false;
            try {
                cedulaSocio = Int32.Parse(cedulaSocioRecibida);
                cedulaEsNumero = true;
            } catch (FormatException) {
                MessageBox.Show("Error, debe ingresar una cédula válida.");
                cedulaEsNumero = false;
            }
            if (cedulaEsNumero) {
                if (BuscarSocioPorCedula(cedulaSocio) == null && BuscarPersonaAutorizadaPorCedula(cedulaSocio) == null) {
                    registrado = false;
                    if (tipoSuscripcion.Equals("VIP") && CuposVIP()) {
                        Socio socioVIP = new Socio("VIP", cedulaSocio, 100000, nombreSocio);
                        for (int i = 0; i < sociosVIP.Length; i++) {
                            if (sociosVIP[i] == null && !registrado) {
                                sociosVIP[i] = socioVIP;
                                registrado = true;
                            }
                        }
                    } else if (tipoSuscripcion.Equals("VIP") && !CuposVIP() && !registrado && CuposRegulares()) {
                        MessageBox.Show("No hay cupos disponibles para VIP");
                    } else if (tipoSuscripcion.Equals("Regular") && CuposRegulares()) {
                        Socio socioRegular = new Socio("Regular", cedulaSocio, 50000, nombreSocio);
                        for (int i = 0; i < sociosRegulares.Length; i++) {
                            if (sociosRegulares[i] == null && !registrado) {
                                sociosRegulares[i] = socioRegular;
                                registrado = true;
                            }
                        }
                    } else if (tipoSuscripcion.Equals("Regular") && !CuposRegulares() && !registrado && CuposVIP()) {
                        MessageBox.Show("No hay cupos disponibles para Regular");
                    }
                    if (registrado) MessageBox.Show("Socio registrado exitosamente.");
                } else MessageBox.Show("Ya hay un socio o una persona autorizada registrado con este número de cédula");
            }
            return registrado;
        }

        public List<List<String>> VerSocios() {
            List<List<String>> listaAtributosSocios = new List<List<String>>();
            for (int i = 0; i < sociosVIP.Length; i++) {
                if (sociosVIP[i] != null) {
                    listaAtributosSocios.Add(new List<String> {sociosVIP[i].CedulaSocio.ToString(),
                        sociosVIP[i].NombreSocio,
                        sociosVIP[i].TipoDeSuscipcionSocio});
                }
            }
            for (int i = 0; i < SociosRegulares.Length; i++) {
                if (sociosRegulares[i] != null) {
                    listaAtributosSocios.Add(new List<String> {sociosRegulares[i].CedulaSocio.ToString(),
                        sociosRegulares[i].NombreSocio,
                        sociosRegulares[i].TipoDeSuscipcionSocio});
                }
            }
            return listaAtributosSocios;
        }
        public void RegistrarFacturaSocio(Consumo consumo, int cedulaResponsable) {
            Socio socio = BuscarSocioPorCedula(cedulaResponsable);
            bool registrado = false;
            for (int i = 0; i < socio.ConsumosSocio.Length; i++) {
                if (socio.ConsumosSocio[i] == null) {
                    if (socio.FondosDisponiblesSocio >= consumo.PrecioConsumo) {
                        socio.ConsumosSocio[i] = consumo;
                        registrado = true;
                        MessageBox.Show("Consumo registrado exitosamente.");
                        break;
                    } else {
                        MessageBox.Show("Error, no cuenta con fondos suficientes.");
                        registrado = true;
                        break;
                    }
                }
            }
            if (!registrado) MessageBox.Show("Ya no hay espacio suficiente para agregar nuevas facturas");
        }

        public List<List<String>> VerFacturasSocio(int cedulaSocio) {
            List<List<String>> listaAtributosFacturasSocio = new List<List<String>>();
            Socio socio = BuscarSocioPorCedula(cedulaSocio);
            if (socio != null) {
                for (int i = 0; i < socio.ConsumosSocio.Length; i++) {
                    if (socio.ConsumosSocio[i] != null) {
                        listaAtributosFacturasSocio.Add(new List<String> {i.ToString(), socio.ConsumosSocio[i].NombreConsumo,
                        socio.ConsumosSocio[i].PrecioConsumo.ToString()});
                    }
                }
                if (listaAtributosFacturasSocio.Count == 0) {
                    MessageBox.Show("No hay facturas pendientes de pago.");
                }
            } else MessageBox.Show("Socio no encontrado");
            return listaAtributosFacturasSocio;
        }

        public bool RegistrarPersonaAutorizadaASocio(int cedulaSocioResponsable, int cedulaPersonaA, String nombrePersonaA) {
            Socio socioResponsable = BuscarSocioPorCedula(cedulaSocioResponsable);
            bool registrado = false;
            if (socioResponsable.FondosDisponiblesSocio != 0) {
                if (BuscarSocioPorCedula(cedulaPersonaA) == null && BuscarPersonaAutorizadaPorCedula(cedulaPersonaA) == null) {
                    PersonaAutorizada personaAutorizada = new PersonaAutorizada(nombrePersonaA, socioResponsable, cedulaPersonaA);
                    for (int i = 0; i < socioResponsable.PersonasAutorizadasSocio.Length; i++) {
                        if (socioResponsable.PersonasAutorizadasSocio[i] == null) {
                            registrado = true;
                            socioResponsable.PersonasAutorizadasSocio[i] = personaAutorizada;
                            MessageBox.Show("Persona autorizada registrada exitósamente.");
                            break;
                        }
                    }
                    if (!registrado) {
                        MessageBox.Show("Ya no hay espacio suficiente para registrar una persona autorizada nueva.");
                    }
                } else MessageBox.Show("Error, ya existe un socio o una persona autorizada con este número de cédula");
            } else MessageBox.Show("Error, el socio no poseé fondos suficientes");
            return registrado;
        }

        public List<List<String>> VerPersonasAutorizadasSocio(int cedulaSocioResponsable) {
            List<List<String>> listaAtributosPersonaA = new List<List<String>>();
            Socio socioResposable = BuscarSocioPorCedula(cedulaSocioResponsable);
            if (socioResposable != null) {
                for (int i = 0; i < socioResposable.PersonasAutorizadasSocio.Length; i++) {
                    if (socioResposable.PersonasAutorizadasSocio[i] != null) {
                        listaAtributosPersonaA.Add(new List<String> {socioResposable.PersonasAutorizadasSocio[i].CedulaPersonaAutorizada.ToString(),
                        socioResposable.PersonasAutorizadasSocio[i].NombrePersonaAutorizada});
                    }
                }
                if (listaAtributosPersonaA.Count == 0) MessageBox.Show("Este socio no tiene personas autorizadas.");
            } else MessageBox.Show("Socio no encontrado");
            return listaAtributosPersonaA;
        }

        public bool AumentarFondosSocio(int cedulaSocio, float aumentoFondos) {
            Socio socio = BuscarSocioPorCedula(cedulaSocio);
            bool fondoAumentado = false;
            if (socio.TipoDeSuscipcionSocio.Equals("VIP")) {
                if (socio.FondosDisponiblesSocio < 5000000) {
                    if (socio.FondosDisponiblesSocio + aumentoFondos > 5000000) {
                        MessageBox.Show("Error, el saldo total no debe sobrepasar los $5'000.000");
                    } else {
                        socio.FondosDisponiblesSocio += aumentoFondos;
                        fondoAumentado = true;
                        MessageBox.Show("Fondos agregados exitósamente.");
                    }
                } else MessageBox.Show("Ya ha alcanzado el máximo de fondos posible");
            } else if (socio.TipoDeSuscipcionSocio.Equals("Regular")) {
                if (socio.FondosDisponiblesSocio < 1000000) {
                    if (socio.FondosDisponiblesSocio + aumentoFondos > 1000000) {
                        MessageBox.Show("Error, el saldo total no debe sobrepasar $1'000.000");
                    } else {
                        socio.FondosDisponiblesSocio += aumentoFondos;
                        fondoAumentado = true;
                        MessageBox.Show("Fondos agregados exitósamente.");
                    }
                } else MessageBox.Show("Ya ha alcanzado el máximo de fondos posible");
            }
            return fondoAumentado;
        }

        public String VerFondosDisponiblesSocio(int cedulaSocio) {
            Socio socio = BuscarSocioPorCedula(cedulaSocio);
            if (socio != null) {
                return socio.FondosDisponiblesSocio.ToString();
            } else MessageBox.Show("Socio no encontrado");
            return null;
        }

        public bool PagarFacturaSocio(int cedulaSocio, int indiceFactura) {
            Socio socio = BuscarSocioPorCedula(cedulaSocio);
            bool pagado = false;
            if (socio.FondosDisponiblesSocio >= socio.ConsumosSocio[indiceFactura].PrecioConsumo) {
                socio.FondosDisponiblesSocio -= socio.ConsumosSocio[indiceFactura].PrecioConsumo;
                socio.ConsumosSocio[indiceFactura] = null;
                MessageBox.Show("Factura pagada exitosamente");
                pagado = true;
            } else MessageBox.Show("Error, fondos insuficientes");
            return pagado;
        }

        public void RegistarFacturaAPersonaAutorizada(Consumo consumo, int cedulaPersonaAutorizada) {
            PersonaAutorizada personaAutorizada = BuscarPersonaAutorizadaPorCedula(cedulaPersonaAutorizada);
            if (personaAutorizada.SocioResponsable.FondosDisponiblesSocio >= consumo.PrecioConsumo) {
                personaAutorizada.FacturasPersonaAutorizada.PushNodo(consumo);
                MessageBox.Show("Consumo registrado exitósamente.");
            } else MessageBox.Show("Error, no cuenta con fondos suficientes.");
        }

        public List<List<String>> VerFacturasPersonaAutorizada(int cedulaPersonaAutorizada) {
            List<List<String>> listaAtributosFacturasPersonaA = new List<List<String>>();
            PersonaAutorizada personaAutorizada = BuscarPersonaAutorizadaPorCedula(cedulaPersonaAutorizada);
            if (personaAutorizada.FacturasPersonaAutorizada.Peek() != null) {
                NodoConsumo siguienteFactura = personaAutorizada.FacturasPersonaAutorizada.Peek();
                do {
                    listaAtributosFacturasPersonaA.Add(new List<String> {siguienteFactura.Consumo.NombreConsumo,
                        siguienteFactura.Consumo.PrecioConsumo.ToString()});
                    siguienteFactura = siguienteFactura.Siguiente;
                } while (siguienteFactura != null);
            } else MessageBox.Show("Esta persona autorizada no tiene facturas.");
            return listaAtributosFacturasPersonaA;
        }

        public bool PagarFacturasPersonaAutorizada(int cedulaPersonaAutorizada) {
            PersonaAutorizada personaAutorizada = BuscarPersonaAutorizadaPorCedula(cedulaPersonaAutorizada);
            bool pagado = false;
            if (personaAutorizada.FacturasPersonaAutorizada.Peek() != null) {
                if (personaAutorizada.SocioResponsable.FondosDisponiblesSocio >= personaAutorizada.FacturasPersonaAutorizada.Peek().Consumo.PrecioConsumo) {
                    personaAutorizada.SocioResponsable.FondosDisponiblesSocio -= personaAutorizada.FacturasPersonaAutorizada.Peek().Consumo.PrecioConsumo;
                    personaAutorizada.FacturasPersonaAutorizada.PopNodo();
                    pagado = true;
                    MessageBox.Show("Consumo pagado exitosamente");
                } else MessageBox.Show("Error, fondos insuficientes");
            } else MessageBox.Show("No hay facturas pendientes de pago.");
            return pagado;
        }

        public bool EliminarSocio(int cedulaSocio) {
            bool eliminado = false;
            Socio socio = BuscarSocioPorCedula(cedulaSocio);
            if (socio.TipoDeSuscipcionSocio != "VIP") {
                bool consumoExistente = false;
                foreach (Consumo consumo in socio.ConsumosSocio) {
                    if (consumo != null) {
                        consumoExistente = true;
                        break;
                    }
                }
                if (!consumoExistente) {
                    int cantidadPersonasAutorizadas = 0;
                    foreach (PersonaAutorizada personaAutorizada in socio.PersonasAutorizadasSocio) {
                        if (personaAutorizada != null) {
                            cantidadPersonasAutorizadas++;
                            if (cantidadPersonasAutorizadas >= 2) {
                                break;
                            }
                        }
                    }
                    if (cantidadPersonasAutorizadas < 2) {
                        bool facturaPendientePersonaAutorizada = false;
                        foreach (PersonaAutorizada personaAutorizada in socio.PersonasAutorizadasSocio) {
                            if (personaAutorizada != null && personaAutorizada.FacturasPersonaAutorizada.Peek() != null) {
                                facturaPendientePersonaAutorizada = true;
                                break;
                            }
                        }
                        if (!facturaPendientePersonaAutorizada) {
                            for (int i = 0; i < sociosRegulares.Length; i++) {
                                if (sociosRegulares[i] != null && sociosRegulares[i].CedulaSocio == cedulaSocio) {
                                    sociosRegulares[i] = null;
                                    eliminado = true;
                                    MessageBox.Show("Socio eliminado exitosamente.");
                                    break;
                                }
                            }
                        } else MessageBox.Show("Error, hay facturas pendiente de pago de una persona autorizada.");
                    }
                } else MessageBox.Show("Error, el socio tiene facturas pendientes de pago.");
            } else MessageBox.Show("Error, no se puede eliminar a un socio VIP.");
            return eliminado;
        }

        public bool EliminarPersonaAutorizada(int cedulaPersonaAutorizada) {
            PersonaAutorizada personaAutorizada = BuscarPersonaAutorizadaPorCedula(cedulaPersonaAutorizada);
            bool eliminado = false;
            if (personaAutorizada.FacturasPersonaAutorizada.Peek() == null) {
                Socio socioResponsable = personaAutorizada.SocioResponsable;
                for (int i = 0; i < socioResponsable.PersonasAutorizadasSocio.Length; i++) {
                    if (socioResponsable.PersonasAutorizadasSocio[i] != null && socioResponsable.PersonasAutorizadasSocio[i].CedulaPersonaAutorizada == cedulaPersonaAutorizada) {
                        socioResponsable.PersonasAutorizadasSocio[i] = null;
                        eliminado = true;
                        MessageBox.Show("Persona autorizada eliminada exitosamente.");
                        break;
                    }
                }
            } else MessageBox.Show("Error, la persona autorizada tiene facturas pendientes de pago.");
            return eliminado;
        }
    }
}
