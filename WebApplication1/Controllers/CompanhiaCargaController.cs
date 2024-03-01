using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class Companhia
{
    public string Nome { get; set; }
}

[Route($"api/companhia-carga")]
[ApiController]
public class CompanhiaCargaController : ControllerBase
{
    private readonly IEnumerable<ICompanhiaCarga> companhiaCargas;

    public CompanhiaCargaController(IEnumerable<ICompanhiaCarga> companhiaCargas)
    {
        this.companhiaCargas = companhiaCargas;
    }

    [HttpGet("{companhia}")]
    public IActionResult Processar(string companhia)
    {

        foreach (var item in companhiaCargas)
        {
            item.Processar();
        }

        var processo = companhiaCargas.FirstOrDefault(filtro => filtro.GetType().Name.Contains(companhia))?.Processar();

        if (processo == null)
        {
            return NotFound();
        }
        Console.WriteLine(companhia);
        return Ok(processo);
    }


    [HttpPost]
    [Produces("application/json")]
    public IActionResult Processar([FromBody]Companhia companhia)
    {

        foreach (var item in companhiaCargas)
        {
            item.Processar();
        }

        var processo = companhiaCargas.FirstOrDefault(filtro => filtro.GetType().Name.Contains(companhia.Nome))?.Processar();

        if (processo == null)
        {
            return NotFound();
        }
        Console.WriteLine(companhia);
        return Ok(processo);
    }
}
