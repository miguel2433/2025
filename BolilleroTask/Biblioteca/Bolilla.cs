using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Bolilla
    {
        public int numeroBolilla {get;set;}
        public Bolilla(int numeroBolilla)
        {
            this.numeroBolilla = numeroBolilla;
        }

        public override bool Equals(object obj) {
        if (obj is Bolilla otra)
                return numeroBolilla == otra.numeroBolilla;
            return false;
        }

        public override int GetHashCode() {
            return numeroBolilla.GetHashCode();
        }
        public override string ToString() => $"{numeroBolilla}";
    }
    
}