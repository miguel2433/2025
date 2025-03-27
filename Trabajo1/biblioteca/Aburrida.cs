using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace biblioteca
{
    public class Aburrida : Estado
    {
        public Aburrida() : base("Aburrida")
        {
            
        }
        public override Estado Comer()
        {
            var estado = base.Comer();

            if(TiempoPasado <= 80)
            {
                estado = PasarAtributosAlNuevoEstado(estado, "Aburrida");
            }
            
            return estado;
        }

        public override Estado Jugar()
        {
            var estado = base.Jugar();
            
            return estado;
        }


    }
}