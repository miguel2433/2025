namespace Bolillero
{
    public class BolilleroClase
    {
        public List<int> bolillas { get; set; } = new List<int>();
        public List<int> bolillasFuera { get; set; } = new List<int>();
        public ILogica logica { get; init; }

        public BolilleroClase(int cantidadBolillas, ILogica logica)
        {
            this.logica = logica;
            GenerarBolillas(cantidadBolillas);
        }

        public void GenerarBolillas(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                bolillas.Add(i + 1);
            }
        }

        public List<int> SacarBolillas(int cantidadBolillasASacarEnLaJugada)
        {
            List<int> bolillasSacadas = logica.SacarBolilla(this, cantidadBolillasASacarEnLaJugada);

            bolillas = bolillas.Except(bolillasSacadas).ToList();
            bolillasFuera.AddRange(bolillasSacadas);

            return bolillasSacadas;
        }

        public bool Jugar(List<int> jugada)
        {
            List<int> bolillasSacadas = SacarBolillas(jugada.Count);

            return CompararRespuesta(bolillasSacadas, jugada);
        }

        public void ReingresarBolillas()
        {
            this.bolillas.AddRange(bolillasFuera);
            this.bolillas = this.bolillas.OrderBy(x => x).ToList(); // Asignamos el resultado de OrderBy a bolillas
            this.bolillasFuera.Clear();
        }

        public bool CompararRespuesta(List<int> bolillasSacadas, List<int> jugada)
        {
            return bolillasSacadas.SequenceEqual(jugada);
        }
    }
}
