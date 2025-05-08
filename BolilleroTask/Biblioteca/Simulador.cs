namespace Biblioteca;
public class Simulador
{
    public long SimulacionSinHilo(Bolillero bolillero, List<int> jugada, int vecesJugar)
    {
        long resultado = bolillero.JugarNVeces(jugada, vecesJugar);
        return resultado;
    }
    public double SimulacionConHilo(Bolillero bolillero, List<int> jugada, int vecesJugar, int cantidadHilosAUsar)
    {
        int repeticionPorHilo = vecesJugar / cantidadHilosAUsar;
        int cantidadBolillasbolillero = bolillero.Bolillas.Count;
        Bolillero[] bolilleros = bolillero.ClonarSiMismo(cantidadHilosAUsar);

        double acum = 0;
        
        System.Console.WriteLine("empieza a crear bolilleros");
        Task<long>[] simulaciones = new Task<long>[cantidadHilosAUsar];
        for(int i = 0; i < cantidadHilosAUsar; i++)
        {
            Console.WriteLine($"Bolillero:  {i}");
            var clon = bolilleros[i];
            simulaciones[i] =
                Task.Run(() => clon.JugarNVeces(jugada, repeticionPorHilo));
        }

        System.Console.WriteLine("fin de crear");

        Task.WaitAll(simulaciones);

        Array.ForEach(simulaciones, s => acum+=s.Result);
        
        return acum;

    }


    long Factorial(int n){
        long resultado = 1;
        for (int i = 2; i <= n; i++){
            resultado *= i;
        }
        return resultado;
    }

    public double Probabilidad(Bolillero bolillero, int longitudJugada, int cantidadDeJugadas){
        int cantidadBolillas = bolillero.Bolillas.Count;
        
        long OrdenPosibles = Factorial(cantidadBolillas) / Factorial(cantidadBolillas - longitudJugada);

        double resultado =  cantidadDeJugadas / OrdenPosibles;

        return resultado;
    }
}