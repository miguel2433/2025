namespace Biblioteca;
public class Simulador
{
    public long SimulacionSinHilo(Bolillero bolillero, List<int> jugada, int vecesJugar)
    {
        long resultado = bolillero.JugarNVeces(jugada, vecesJugar);
        return resultado;
    }
    private Task<long>[] CrearSimulaciones(Bolillero bolillero, List<int> jugada, int vecesJugar, int cantidadHilosAUsar)
    {
        int repeticionPorHilo = vecesJugar / cantidadHilosAUsar;
        int cantidadBolillasbolillero = bolillero.Bolillas.Count;
        Bolillero[] bolilleros = bolillero.ClonarSiMismo(cantidadHilosAUsar);

        Task<long>[] simulaciones = new Task<long>[cantidadHilosAUsar];
        for(int i = 0; i < cantidadHilosAUsar; i++)
        {
            Console.WriteLine($"Bolillero:  {i}");
            var clon = bolilleros[i];
            simulaciones[i] = Task.Run(() => clon.JugarNVeces(jugada,repeticionPorHilo));
        }
        return simulaciones;
    }
    public async Task<double> SimularConHilosAsync(Bolillero bolillero, List<int> jugada, int vecesJugar, int cantidadHilosAUsar)
    {
        Task<long>[] simulaciones = CrearSimulaciones(bolillero, jugada, vecesJugar, cantidadHilosAUsar);
        double acum = 0;
        await Task.WhenAll(simulaciones);
        Array.ForEach(simulaciones, s => acum+=s.Result);
        return acum;
    }
    public double SimulacionConHilo(Bolillero bolillero, List<int> jugada, int vecesJugar, int cantidadHilosAUsar)
    {
        Task<long>[] simulaciones = CrearSimulaciones(bolillero, jugada, vecesJugar, cantidadHilosAUsar);
        double acum = 0;
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
    
    public async Task<long> ParallelAsync(Bolillero bolillero, List<int> jugada, int vecesJugar, int cantidadHilosAUsar)
    {
        Bolillero[] bolilleros = bolillero.ClonarSiMismo(cantidadHilosAUsar);
        int repeticionPorHilo = vecesJugar / cantidadHilosAUsar;
        int cantidadSimulaciones = bolilleros.Count();
        long[] resultados = new long[cantidadSimulaciones];

        // await Parallel.ForAsync<long>(0,
        //                             cantidadSimulaciones,
        //                             async(i, ct) =>
        //                             {
        //                                 resultados[i] = bolilleros[i].JugarNVeces(jugada, repeticionPorHilo);
        //                             }
        // );
        await Task.Run( () =>
        Parallel.For(0,
                    cantidadSimulaciones,
                    i =>
                        {
                            resultados[i] = (long)bolilleros[i].JugarNVeces(jugada, repeticionPorHilo);
                        }
            )
        );

    
        return resultados.Sum();
    }
}