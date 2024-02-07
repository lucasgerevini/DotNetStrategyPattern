namespace WebApplication1;

public class Azul : ICompanhiaCarga
{
    public string Processar()
    {
        string processado = $"{nameof(Azul)} - {nameof(Processar)}";
        Console.WriteLine(processado);
        return processado;
    }
}
