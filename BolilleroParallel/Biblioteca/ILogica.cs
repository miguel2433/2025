namespace Biblioteca;

public interface ILogica
{
    void OrdenarBolillero(Bolillero bolillero);
    public List<Bolilla> SacarBolillas(Bolillero bolillero, int cantidadBolillasASacarEnLaJugada);
}