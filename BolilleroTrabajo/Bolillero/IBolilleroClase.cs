namespace Bolillero;

public interface IBolilleroClase
{
    List<Bolilla> Bolillas {get; set;}
    void GenerarBolillas(int cantidadBolillas);
    List<Bolilla> GeneradorAzar(int cantidadBolillas);
    bool CompararRespuesta(List<Bolilla> bolillasSacadas, List<Bolilla> jugada);
    bool Jugar(List<int> jugada);
}