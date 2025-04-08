using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillero
{
    public class BolilleroClase : IBolilleroClase
    {
        public List<Bolilla> Bolillas {get;set;} = new List<Bolilla>();

        public BolilleroClase(int cantidadBolillasBolillero)
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
            int limite = Bolillas.Max(bolilla => bolilla.numeroBolilla);
            List<Bolilla> BolillasSacadas = new();
            Random rnd = new();
            for(int i = 1; i <= cantidadBolillas; i++){
                Bolilla bolillaSacada = new Bolilla(rnd.Next(0, limite));
                while(BolillasSacadas.Any(bolilla => bolilla.numeroBolilla == bolillaSacada.numeroBolilla)){
                    bolillaSacada = new Bolilla(rnd.Next(0, limite));
                }
                BolillasSacadas.Add(bolillaSacada);
                Bolillas.Remove(bolillaSacada);
            }

            return BolillasSacadas;
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
            var lista = GeneradorAzar(jugada.Count());
            Console.WriteLine("lista girada: " + lista);
            bool resultado = CompararRespuesta(lista, bolillas);
            return resultado;
        }
    }
}
