using Application.Features.Form.Commands.Request;
using Application.Features.Form.Queries.Request;
using Application.Features.FormQuestions;
using Application.Features.QuestionOptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormsController(IMediator mediator) { 
            _mediator = mediator;
        }
        [HttpPost("formById")]
        public async Task<IActionResult> GetFormById( GetFormByIdQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("createForm")]
        public async Task<IActionResult> CreateForm(CreateFormCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("createQuestion")]
        public async Task<IActionResult> CreateFormQuestion( CreateFormQuestionCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("createQuestionOpt")]
        public async Task<IActionResult> CreateQuestionOpt( CreateQuestionOptCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("forms")]
        public async Task<IActionResult> GetAllForms(GetAllFormsQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
