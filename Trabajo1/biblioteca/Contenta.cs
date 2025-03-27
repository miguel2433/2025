using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace biblioteca
{
    public class Contenta : Estado
    {
        public Contenta() : base("Contenta")
        {
            
        }
        public override Estado Comer()
        {   
            var estado = base.Comer();

            estado.NivelFelicidad ++;
            
            return estado;
        }

        public override Estado Jugar()
        {
            var estado = base.Jugar();

            estado.NivelFelicidad += 2;
            if(VecesJugado > 5){
                estado = PasarAtributosAlNuevoEstado(estado, "Hambrienta");
            }
            return estado;
        }
    }
}