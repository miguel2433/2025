
namespace Bolillero;

public class SacarRandom : ILogica
{
    public int[] SacarBolilla(int cantidad, int rango)
    {
        Random random = new Random();

        int[] resultado = new int[cantidad];
        for(int i = 0; i <= cantidad; i++)
        {
            resultado[i] = random.Next(1, rango);
        }
        return resultado;
    }
}