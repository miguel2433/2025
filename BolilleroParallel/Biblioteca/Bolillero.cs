using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca;

public class Bolillero : IClonable<Bolillero>
{
    public List<Bolilla> Bolillas {get;set;} = new List<Bolilla>();

    public ILogica logica { get; init; }

    public List<Bolilla> BolillasAfueras { get; set; } = new List<Bolilla>();

    public Bolillero(int cantidadBolillasBolillero, ILogica logica)
    {
        this.logica = logica;
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

    public List<Bolilla> SacarBolillas(int cantidadBolillasASacarEnLaJugada)
    {
        List<Bolilla> bolillasSacadas = logica.SacarBolillas(this, cantidadBolillasASacarEnLaJugada);

        Bolillas = Bolillas.Except(bolillasSacadas).ToList();

        BolillasAfueras = bolillasSacadas;

        return bolillasSacadas;
    }

    public bool CompararRespuesta(List<Bolilla> bolillasSacadas, List<Bolilla> jugada)
    {
        bool resultado = true;
        if(!bolillasSacadas.SequenceEqual(jugada)){
            return false;
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
        var lista = SacarBolillas(jugada.Count());
        bool resultado = CompararRespuesta(lista, bolillas);
        return resultado;
    }
    public void ReingresarBolilla()
    {
        Bolillas.AddRange(BolillasAfueras);
        Bolillas.OrderBy(Bolilla => Bolilla.numeroBolilla).ToList();
        logica.OrdenarBolillero(this);
        BolillasAfueras.Clear();
    }

    public long JugarNVeces(List<int> jugada, int vecesJugar)
    {
        long resultadoAcertado = 0;
        for(int i = 0; i < vecesJugar; i++)
        {
            if(Jugar(jugada))
            {
                resultadoAcertado++;
            }
            ReingresarBolilla();
        }
        System.Console.WriteLine("fin de este bolillero");
        return resultadoAcertado;
    }

    public Bolillero[] ClonarSiMismo(int cantidadDeClones)
    {
        Bolillero[] bolilleros = new Bolillero[cantidadDeClones];

        // bolilleros1.Add(this);
        // while(bolilleros1.Count() + bolilleros.Count() <= cantidadDeClones)
        // {
        //     bolilleros1.AddRange(bolilleros1);
        // }
        for(int i = 0; i < cantidadDeClones; i++)
        {
            bolilleros[i] = new Bolillero(this.Bolillas.Count, this.logica);
        }
        return bolilleros;
    }
}
