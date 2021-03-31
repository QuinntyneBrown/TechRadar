using System.Net;
using System.Threading.Tasks;
using TechRadar.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TechRadar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlipController
    {
        private readonly IMediator _mediator;

        public BlipController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{blipId}", Name = "GetBlipByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBlipById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBlipById.Response>> GetById([FromRoute]GetBlipById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Blip == null)
            {
                return new NotFoundObjectResult(request.BlipId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetBlipsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBlips.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBlips.Response>> Get()
            => await _mediator.Send(new GetBlips.Request());
        
        [HttpPost(Name = "CreateBlipRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBlip.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBlip.Response>> Create([FromBody]CreateBlip.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateBlipRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBlip.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBlip.Response>> Update([FromBody] UpdateBlip.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetBlipsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBlipsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBlipsPage.Response>> Page([FromRoute]GetBlipsPage.Request request)
            => await _mediator.Send(request);
        
    }
}
