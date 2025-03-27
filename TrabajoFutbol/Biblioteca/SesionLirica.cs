namespace Biblioteca;

public class SesionLirica : Sesion
{
    public SesionLirica() : base("Lirica")
    {
    }

    public override void AplicarAl(Jugador jugador)
    {
        jugador.AplicarEntrenamientoLirico();
    }
}