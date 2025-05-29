// See https://aka.ms/new-console-template for more information
using Biblioteca;
using System.Numerics; // ¡Esta línea es clave!
    ILogica logicaTestRandom = new LogicaRandom();
Simulador simulador = new Simulador();
Bolillero bolilleroRandom = new Bolillero(20, logicaTestRandom);

        int cantidadDeTiradas = 1_000_000_000;
        List<int> listaJugada = new List<int>{0, 2, 1, 4};

        double valorReal = simulador.SimulacionConHilo(bolilleroRandom, listaJugada, cantidadDeTiradas, 12);
        
        double teoria = simulador.Probabilidad(bolilleroRandom, listaJugada.Count,cantidadDeTiradas);
        
        double teoriapor100 = teoria;
        
        double valorRealpor100 = valorReal ;
        Console.WriteLine($"{valorRealpor100}, {teoriapor100}");