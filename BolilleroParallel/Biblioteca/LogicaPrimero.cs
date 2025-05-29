
namespace Biblioteca;

public class LogicaPrimero : ILogica
{
    public void OrdenarBolillero(Bolillero bolillero)
        => bolillero.Bolillas = [.. bolillero.Bolillas.OrderBy(b => b.numeroBolilla)];

    public List<Bolilla> SacarBolillas(Bolillero bolillero, int cantidadBolillasASacarEnLaJugada)
    {
        List<Bolilla> BolillasSacadas = bolillero.Bolillas.Select(Bolilla => Bolilla).Take(cantidadBolillasASacarEnLaJugada).ToList();

        return BolillasSacadas;
    }
}