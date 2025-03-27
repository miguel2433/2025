namespace Biblioteca;

public class Atacante : ITipoJugador
{
    public double Anotacion { get; set; } = 0;
    public void AplicarEntrenamientoFisico(Jugador jugador)
    {
        jugador.Potencia += 1;
        jugador.HabilidadEnLosPases += 0.5;
    }

    public void AplicarEntrenamientoLirico(Jugador jugador)
    {
        Anotacion += 0.5;
        jugador.HabilidadEnLosPases += 1;
    }

    public void AplicarEntrenamientoTactico(Jugador jugador)
    {
        jugador.HabilidadEnLosPases += 0.5;
        jugador.VisionDelJuego += 0.5;
        jugador.VisionDeLosCompanieros += 0.5;
    }

    public double GetPrecision(Jugador jugador)
    {
        return Anotacion;
    }

    public double GetVisionGeneral(Jugador jugador)
    {
        return jugador.VisionDelJuego + jugador.HabilidadEnLosPases; 
    }
}