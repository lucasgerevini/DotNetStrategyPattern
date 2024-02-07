namespace WebApplication1;

public class Allianz : ICompanhiaCarga
{
    public string Processar()
    {
        string processado = $"{nameof(Allianz)} - {nameof(Processar)}";
        Console.WriteLine(processado);
        return processado;
    }
}
