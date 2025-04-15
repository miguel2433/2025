namespace Bolillero
{
    public class SacarPrimero : ILogica
    {

        public int[] SacarBolilla(int cantidad, int rango)
        {
            if(!verification.comparacionNumeroMenor(cantidad,rango)){
                throw new Exception("las bolillas creadads son mayores a las del bolillero");
            }
            int[] resultado = new int[cantidad];
            for(int i = 0; i <= cantidad; i++)
            {
                resultado[i] =  i + 1;
            }
            return resultado;
        }
    }
}