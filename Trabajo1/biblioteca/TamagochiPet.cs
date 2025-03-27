using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca
{
    public class TamagochiPet
    {
        public Estado estado {get; set ;} = new Aburrida();

        public string Nombre {get; set;}

        public void Jugar()
        {
            estado = estado.Jugar();
        }

        public void Comer()
        {
            estado = estado.Comer();
        }

        public void JugariasConmigo()
        {
            estado = estado.JugariasConmigo();
        }

        public void MostrarEstado()
        {
            Console.WriteLine(estado.Nombre);
        }

        public void PasarTiempo()
        {
            if(estado.Nombre == "Aburrida")
            {
                estado.TiempoPasado += 200;
            }
            else
            {
                Console.WriteLine("No estoy aburrida");
            }
        }

        public TamagochiPet(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}