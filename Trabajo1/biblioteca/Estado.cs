namespace biblioteca
{
    public abstract class Estado : IEstado
    {
        public string Nombre { get; set; }
        public short NivelFelicidad {get;set;} = 0;
        public uint TiempoPasado {get; set;} = 0;
        public short VecesJugado {get;set;} = 0;

        public virtual Estado Comer()
        {

            var estado = PasarAtributosAlNuevoEstado(this, "Contenta");

            estado.VecesJugado = 0;

            return estado;
        }

        public virtual Estado Jugar()
        {
            VecesJugado++;
            
            var estado = PasarAtributosAlNuevoEstado(this, "Contenta");

            return estado;
        }

        public virtual Estado JugariasConmigo()
        {
            throw new NotImplementedException();
        }
        public Estado(string Nombre)
        {
            this.Nombre = Nombre;
        }


        public static Estado PasarAtributosAlNuevoEstado(Estado estadoViejo, string estadoOutput)
        {

            Estado estadoNuevo = new Contenta();

            if(estadoOutput == "Aburrida")
            {
                estadoNuevo = new Aburrida();
            }
            else if(estadoOutput == "Hambrienta")
            {
                estadoNuevo = new Hambrienta();
            }
            
            estadoNuevo.NivelFelicidad = estadoViejo.NivelFelicidad;
            estadoNuevo.TiempoPasado = estadoViejo.TiempoPasado;
            estadoNuevo.VecesJugado = estadoViejo.VecesJugado;
            
            return estadoNuevo;
        }
    }
}