using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using biblioteca;
namespace Test;

public class TestTamagochiContenta
{

    TamagochiPet mascota;
    public TestTamagochiContenta() => mascota = new TamagochiPet("Cheng");
    //Contenta
    [Fact]
    public void TestJuegaCuandoEstaContenta()
    {
        mascota.Jugar();

        mascota.Jugar();


        Assert.IsType<Contenta>(mascota.estado);
        Assert.Equal<short>(2, mascota.estado.NivelFelicidad);
        Assert.Equal<short>(2, mascota.estado.VecesJugado);
    }

    [Fact]
    public void TestJuegaCuandoJuegaMasDeCincoVeces()
    {

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        Assert.IsType<Hambrienta>(mascota.estado);
        Assert.Equal<short>(10, mascota.estado.NivelFelicidad);
        Assert.Equal<short>(6, mascota.estado.VecesJugado);
    }

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
    public void TestJuegaMenosDeCincoVecesYCome()
    {

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Comer();

        mascota.Jugar();

        mascota.Jugar();

        mascota.Jugar();


        Assert.IsType<Contenta>(mascota.estado);
        Assert.Equal<short>(11, mascota.estado.NivelFelicidad);
        Assert.Equal<short>(3 , mascota.estado.VecesJugado);
    }
}