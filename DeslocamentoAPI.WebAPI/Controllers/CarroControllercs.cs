﻿using DeslocamentoAPI.Application.Documentos.Commands.Carros;
using DeslocamentoAPI.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoAPI.WebAPI.Controllers
{
    public class CarroController : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
