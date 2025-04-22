
namespace Bolillero;

public class SacarRandom : ILogica
{
    public List<int> SacarBolilla(BolilleroClase bolillero, int cantidadBolillasASacarEnLaJugada)
    {
        List<int> bolillasDisponibles = bolillero.bolillas.ToList();
        List<int> bolillasSacadas = new();
        Random rnd = new();

        for (int i = 0; i < cantidadBolillasASacarEnLaJugada && bolillasDisponibles.Count > 0; i++)
        {
            int index = rnd.Next(0, bolillasDisponibles.Count);
            int bolillaSacada = bolillasDisponibles[index];
            bolillasSacadas.Add(bolillaSacada);
            bolillasDisponibles.RemoveAt(index); 
        }

        return bolillasSacadas;
    }
}