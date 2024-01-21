using CondoTec.Management.Application.Claims;
using CondoTec.Management.Application.Commands.Condominios.UseCases.AddCondominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoTec.Management.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize]
    public class CondominioController(IMediator mediator) : Controller
    {
        private readonly ISender _sender = mediator;

        [HttpPost]
        [Route("addCondominio", Name = nameof(AddCondominio))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ClaimsAuthorize(ClaimTypes.Condominio, "Insert")]
        public async Task<IActionResult> AddCondominio([FromBody] AddCondominioCommand condominioCommand, CancellationToken cancellationToken)
        {
            var apiResponse = await _sender.Send(condominioCommand, cancellationToken);
            return Created("/addReceipt", apiResponse);
        }
    }
}
