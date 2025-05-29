namespace Biblioteca;

public interface IClonable<T>
{
    public T[] ClonarSiMismo(int cantidadDeClones);
}