namespace Bolillero
{
    public class SacarPrimero : ILogica
    {

        public List<int> SacarBolilla(BolilleroClase bolillero, int cantidadBolillasASacarEnLaJugada)
        {
        List<int> BolillasSacadas = bolillero.bolillas.Take(cantidadBolillasASacarEnLaJugada).ToList();

        return BolillasSacadas;
        }
    }
}