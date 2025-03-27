namespace Biblioteca;

public interface ITipoJugador
{
    double GetPrecision(Jugador jugador);
    double GetVisionGeneral(Jugador jugador);
    void AplicarEntrenamientoFisico(Jugador jugador);
    void AplicarEntrenamientoLirico(Jugador jugador);
    void AplicarEntrenamientoTactico(Jugador jugador);
}