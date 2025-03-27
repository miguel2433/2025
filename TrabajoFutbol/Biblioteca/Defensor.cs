namespace Biblioteca;

public class Defensor : ITipoJugador
{
    public double Quite = 0;
    public void AplicarEntrenamientoFisico(Jugador jugador)
    {
        jugador.Potencia += 1;
        jugador.HabilidadEnLosPases += 0.5;
        Quite += 0.5;
    }

    public void AplicarEntrenamientoLirico(Jugador jugador)
    {
        jugador.HabilidadEnLosPases += 1;
        jugador.VisionDelJuego += 0.5;
    }

    public void AplicarEntrenamientoTactico(Jugador jugador)
    {
        jugador.VisionDelJuego += 0.5;
        jugador.VisionDeLosCompanieros += 1;
    }

    public double GetPrecision(Jugador jugador)
    {
        return Quite;
    }

    public double GetVisionGeneral(Jugador jugador)
    {
        return jugador.VisionDeLosCompanieros + jugador.VisionDelJuego;
    }
}