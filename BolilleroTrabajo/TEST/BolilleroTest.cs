using Bolillero;

namespace BolilleroTest
{
    public class BolilleroTest
    {
        public BolilleroClase bolillero;

        public BolilleroTest()
        {
            ILogica logica = new SacarPrimero();
            bolillero = new BolilleroClase(10, logica);
        }

        [Fact]
        public void VerificarCantidadBolilleroAlCrearBolillero()
        {
            Assert.Equal(10, bolillero.bolillas.Count);
        }

        [Fact]
        public void JugarGana()
        {
            List<int> jugada = new List<int> { 1, 2, 3, 4, 5 };
            Assert.True(bolillero.Jugar(jugada));
        }
        [Fact]
        public void JugarPierde(){
            List<int> jugada = new List<int>{4, 2, 1};
            Assert.False(bolillero.Jugar(jugada));
        }

        [Fact]
        public void BolillasFuera5(){
            List<int> jugada = new List<int> { 1, 2, 3, 4, 5 };
            bolillero.Jugar(jugada);

            Assert.Equal(5, bolillero.bolillas.Count);
            Assert.Equal(5,bolillero.bolillasFuera.Count);
        }

        [Fact]
        public void ReingresarBolillas(){
            List<int> jugada = new List<int> { 1, 2, 3, 4, 5 };

            bolillero.Jugar(jugada);

            bolillero.ReingresarBolillas();

            Assert.Equal(10, bolillero.bolillas.Count);
            Assert.Empty(bolillero.bolillasFuera);
        }
            [Fact]
        public void GanarNVeces()
        {
            List<int> jugada = new List<int> {1, 2};

            Assert.True(bolillero.Jugar(jugada));

            //? 
        } 
    }
}
