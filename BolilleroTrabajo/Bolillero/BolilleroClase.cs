namespace Bolillero
{
    public class BolilleroClase
    {
        public int[] bolillas {get;set;}
        public int[] bolillasFuera {get;set;}
        public ILogica logica {get; init;}
        
        public BolilleroClase(int cantidadBolillas){
            bolillas = new int[cantidadBolillas];
            GenerarBolillas(cantidadBolillas);
        }
        
        public void GenerarBolillas(int cantidad){
            for(int i = 0; i <= cantidad; i++){
                bolillas[i] = i + 1;
            } 
        }

    }
}