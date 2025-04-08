using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero;

public class BolilleroTest : IBolilleroClase
{
    public List<Bolilla> Bolillas {get;set;} = new List<Bolilla>();

    public BolilleroTest(int cantidadBolillasBolillero)
    {
        GenerarBolillas(cantidadBolillasBolillero);
    }

    public void GenerarBolillas(int cantidadBolillas)
    {
        Bolillas.Clear();
        for(int i = 0; i < cantidadBolillas; i++)
        {
            Bolilla bolilla = new Bolilla(i);
            Bolillas.Add(bolilla);
        }
    }

    public List<Bolilla> GeneradorAzar(int cantidadBolillas)
    {
        List<Bolilla> BolillasSacadas = Bolillas.Select(Bolilla => Bolilla).Take(cantidadBolillas).ToList();
        foreach(Bolilla bolilla in BolillasSacadas)
        {
            System.Console.WriteLine(bolilla.numeroBolilla);
        }
        return BolillasSacadas;
    }

    public bool CompararRespuesta(List<Bolilla> bolillasSacadas, List<Bolilla> jugada)
    {
        bool resultado = true;
        if(!bolillasSacadas.SequenceEqual(jugada)){
            return false;
        }
        for(int i = jugada.Count(); i <= bolillasSacadas.Count(); i++)
        {
            System.Console.WriteLine(jugada[i]);
            System.Console.WriteLine(bolillasSacadas[i]);
        }
        return resultado;
    }

    public bool Jugar(List<int> jugada)
    {
        List<Bolilla> bolillas = new List<Bolilla>();
        foreach(int numero in jugada)
        {
            bolillas.Add(new Bolilla(numero));
        }
        var lista = GeneradorAzar(jugada.Count());
        Console.WriteLine("lista girada: " + lista);
        bool resultado = CompararRespuesta(lista, bolillas);
        return resultado;
    }
}
