using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using biblioteca;
namespace Test;

public class TestTamagochiAburrida
{
    TamagochiPet mascota;
    public TestTamagochiAburrida() => mascota = new TamagochiPet("Davis");
    [Fact]
    public void TestCrearMascotaYQueEsteAburrida()
    {

        //Assert.Equal<string>(mascota.estado.Nombre, "Aburrida");
        Assert.IsType<Aburrida>(mascota.estado);

    }

    //Aburrida
    [Fact]
    public void TestJuegaCuandoEstaAburridaYJuegaSePoneContenta()
    {

        mascota.Jugar();
        Assert.IsType<Contenta>(mascota.estado);
    }
    [Fact]

    public void TestComeCuandoElTiempoNoPasaOchentaMinutos()
    {

        mascota.Comer();

        Assert.IsType<Aburrida>(mascota.estado);
    }
    [Fact]
    public void TestComeCuandoElTiempoPasaOchentaMinutos()
    {

        mascota.PasarTiempo();

        mascota.Comer();

        Assert.IsType<Contenta>(mascota.estado);
    }
}