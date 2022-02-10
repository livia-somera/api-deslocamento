using DeslocamentoAPI.Application.Documentos.Commands.Condutores;
using DeslocamentoAPI.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoAPI.WebAPI.Controllers
{
    public class CondutorController : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
