using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Biblioteca;
using System.Numerics;
namespace TestUnitario;

public class BolilleroXUnit
{
    ILogica logicaTest = new LogicaPrimero();
    ILogica logicaTestRandom = new LogicaRandom();
    Bolillero bolillero;
    Bolillero bolilleroRandom;
    Simulador simulador;
    public BolilleroXUnit(){
        bolilleroRandom = new Bolillero(20, logicaTestRandom);
        bolillero  = new Bolillero(10, logicaTest);
        this.simulador = new Simulador();
    }

    [Fact]
    public void VerificarCantidadBolilleroAlCrearBolillero()
    {
        Assert.Equal(10, bolillero.Bolillas.Count());
    }

    [Fact]
    public void SacarBolilla()
    {
        List<int> bolilla = new List<int>(){0};
        Assert.True(bolillero.Jugar(bolilla));
        Assert.True(bolillero.Bolillas.Count() == 9);
        Assert.True(bolillero.BolillasAfueras.Count() == 1);
        //no tengo un lugar donde simule afuera del bolillero, no se si es necesario y no lo dice en el texto,entonces no lo hice
    }
    [Fact]
    public void ReingresarBolilla()
    {
        List<int> bolilla = new List<int>(){0};
        Assert.True(bolillero.Jugar(bolilla));
        Assert.True(bolillero.Bolillas.Count() == 9);
        bolillero.ReingresarBolilla();
        Assert.Equal(10, bolillero.Bolillas.Count());
    }

    [Fact]
    public void JugarGana(){
        List<int> jugada = new List<int>{0, 1, 2, 3, 4};
        Assert.True(bolillero.Jugar(jugada));
    }

    [Fact]
    public void JugarPierde(){
        List<int> jugada = new List<int>{4, 2, 1};
        Assert.False(bolillero.Jugar(jugada));
    }
    [Fact]
    public void GanarNVeces()
    {
        List<int> jugada = new List<int> {0, 1};

        Assert.True(bolillero.Jugar(jugada));

        //no estoy seguro si es lo que se pide hacer. 
    } 
    [Fact]
    public void SimulacionConHilos()//Expansion de dominio calentar sandwich
    {
        
        int cantidadDeTiradas = 1_000_000;
        List<int> listaJugada = new List<int>{0, 2, 1, 4};

        double valorReal = simulador.SimulacionConHilo(bolilleroRandom, listaJugada, cantidadDeTiradas, 12);
        
        double teoria = simulador.Probabilidad(bolilleroRandom, listaJugada.Count,cantidadDeTiradas);
        
        double teoriapor100 = teoria*100;
        
        double valorRealpor100 = valorReal * 100;
        Assert.Equal(valorRealpor100/cantidadDeTiradas, teoriapor100/cantidadDeTiradas);
    }
    
    [Fact]
    public async void SimularConHilosAsync()
    {
        int cantidadDeTiradas = 1_000_000;
        List<int> listaJugada = new List<int>{0, 2, 1, 4};

        double valorReal = await simulador.SimularConHilosAsync(bolilleroRandom, listaJugada, cantidadDeTiradas, 12);
        
        double teoria = simulador.Probabilidad(bolilleroRandom, listaJugada.Count,cantidadDeTiradas);
        
        double teoriapor100 = teoria*100;
        
        double valorRealpor100 = valorReal * 100;
        Assert.Equal(valorRealpor100/cantidadDeTiradas, teoriapor100/cantidadDeTiradas);
    }
    [Fact]
    public async void ParallelAsync()
    {
        int cantidadDeTiradas = 1_000_000;
        List<int> listaJugada = new List<int>{0, 2, 1, 4};

        double valorReal = await simulador.ParallelAsync(bolilleroRandom, listaJugada, cantidadDeTiradas, 12);
        
        double teoria = simulador.Probabilidad(bolilleroRandom, listaJugada.Count,cantidadDeTiradas);
        
        double teoriapor100 = teoria*100;
        
        double valorRealpor100 = valorReal * 100;
        Assert.Equal(valorRealpor100/cantidadDeTiradas, teoriapor100/cantidadDeTiradas);
    }
}