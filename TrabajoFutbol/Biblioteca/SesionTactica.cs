
namespace Biblioteca;

public class SesionTactica : Sesion
{
    public SesionTactica() : base("Tactica")
    {
    }

    public override void AplicarAl(Jugador jugador)
    {
        jugador.AplicarEntrenamientoTactico();
    }
}