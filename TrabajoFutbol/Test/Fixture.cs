using Biblioteca;

namespace Test;

public class Fixture
{
    Jugador jugador1 ;
    Jugador jugador2 ;
    Jugador jugador3 ;
    Jugador jugador4 ;
    public Equipo equipo;
    public Fixture()
    {
        jugador1 = new(new Atacante(), 1, 1, 1, 1);
        jugador2 = new(new Defensor(), 2, 2, 2, 2);
        jugador3 = new(new Atacante(), 3, 3, 3, 3);
        jugador4 = new(new Defensor(), 4, 4, 4, 4);
        equipo = new Equipo();
        equipo.Jugadores = [jugador1, jugador2, jugador3, jugador4];

    }
}