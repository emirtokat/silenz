using Application.Features.Form.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("operatorById")]
        public async Task<IActionResult> GetOperatorById([FromQuery] GetOperatorByIdQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("operators")]
        public async Task<IActionResult> GetAllOperator([FromQuery] GetAllOperatorsQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
