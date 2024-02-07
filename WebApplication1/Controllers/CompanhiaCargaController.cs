using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanhiaCargaController : ControllerBase
    {
        private readonly IEnumerable<ICompanhiaCarga> companhiaCargas;

        public CompanhiaCargaController(IEnumerable<ICompanhiaCarga> companhiaCargas)
        {
            this.companhiaCargas = companhiaCargas;
        }

        [HttpGet("/{companhia}")]
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
    }
}
