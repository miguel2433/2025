using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using biblioteca;
namespace Test;

public class TestTamagochiHambrienta
{
    TamagochiPet mascota;

    public TestTamagochiHambrienta() => mascota = new TamagochiPet("Miguel");


    [Fact]
    public void TestJuegaCuandoJuegaMasDeCincoVecesYCome()
    {

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Comer();

        Assert.IsType<Contenta>(mascota.estado);
        Assert.Equal<short>(10, mascota.estado.NivelFelicidad);
        Assert.Equal<short>(0 , mascota.estado.VecesJugado);
    }

    [Fact]
    public void TestJugarCuandoEstaHambrienta()
    {

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();
        Assert.Throws<InvalidOperationException>(() => mascota.Jugar());
    }
}