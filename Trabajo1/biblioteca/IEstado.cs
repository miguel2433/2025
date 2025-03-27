using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca
{
    public interface IEstado
    {
        Estado Jugar();
        Estado Comer();
        Estado JugariasConmigo();
    }
}