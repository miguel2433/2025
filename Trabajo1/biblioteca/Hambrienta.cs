namespace biblioteca;

public class Hambrienta : Estado
{
    public Hambrienta() : base("Hambrienta")
    {
        
    }
    public override Estado Comer()
    {
        var estado = base.Comer();

        return estado;
    }

    public override Estado Jugar()
    {
        throw new InvalidOperationException("Objection!!!");
    }


}