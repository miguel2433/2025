using Biblioteca;

namespace Test
{
    public class EquipoXunit
    {
        Fixture fixture;
        public EquipoXunit()
        {
            fixture = new Fixture();

        }
        [Fact]
        public void GetPrecision()
        {
            // Given

            double Precicion = fixture.equipo.GetPrecision();
            Assert.Equal<double>(30, Precicion);
        }

        [Fact]
        public void GetVision()
        {
            // Given

            double vision = fixture.equipo.GetVision();
            Assert.Equal<double>(20, vision);
        }

        [Fact]
        public void GetPotencia()
        {
            // Given

            double vision = fixture.equipo.GetPotencia();
            Assert.Equal<double>(7, vision);
        }

        [Theory]
        [InlineData(0, 2, 1.5, 1.5, 3, .5)]
        [InlineData(1, 3, 3, 3, 3.5, .5)]
        [InlineData(2, 4, 3.5, 3.5, 5, .5)]
        [InlineData(3, 5, 5, 5, 5.5, .5)]
        public void Entrenar(int nmJugador, double Potencia, double VisionDelJuego, double VisionDeLosCompanieros, double HabilidadEnLosPases, double Precicion)
        {
            fixture.equipo.Entrenar();
            Assert.Equal<double>(Potencia, fixture.equipo.Jugadores[nmJugador].Potencia);
            Assert.Equal<double>(VisionDelJuego, fixture.equipo.Jugadores[nmJugador].VisionDelJuego);
            Assert.Equal<double>(VisionDeLosCompanieros, fixture.equipo.Jugadores[nmJugador].VisionDeLosCompanieros);
            Assert.Equal<double>(HabilidadEnLosPases, fixture.equipo.Jugadores[nmJugador].HabilidadEnLosPases);
            Assert.Equal<double>(Precicion, fixture.equipo.Jugadores[nmJugador].GetPrecision());
        }
    }
}