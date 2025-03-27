
namespace Biblioteca;

public abstract class Sesion
{

    public string Nombre { get; set; }

    protected Sesion(string Nombre)
    {
        this.Nombre = Nombre; 
    }
    
    public abstract void AplicarAl(Jugador jugador);
}