using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero
{
    public static class verification
    {
        public static bool comparacionNumeroMenor(int a, int b){
            if(a < b){
                return false;
            }
            else{
                return true;
            }
        }
    }
}