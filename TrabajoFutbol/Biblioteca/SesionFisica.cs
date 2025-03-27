namespace Biblioteca;

public class SesionFisica : Sesion
{
    public SesionFisica() : base("Fisica")
    {
    }

    public override void AplicarAl(Jugador jugador)
    {
        jugador.AplicarEntrenamientoFisico();
    }
}