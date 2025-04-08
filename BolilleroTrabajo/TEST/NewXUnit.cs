using Xunit;
using Bolillero;

namespace TEST
{
    public class NewXUnit
    {
        IBolilleroClase bolillero = new BolilleroTest(10);

        public NewXUnit() => bolillero  = new BolilleroTest(10);

        [Fact]
        public void VerificarCantidadBolilleroAlCrearBolillero()
        {
            Assert.Equal(10, bolillero.Bolillas.Count());
        }

        [Fact]
        public void JugarGana(){
            List<int> jugada = new List<int>{0, 1, 2, 3, 4};
            Assert.True(bolillero.Jugar(jugada));
        }

    }
}