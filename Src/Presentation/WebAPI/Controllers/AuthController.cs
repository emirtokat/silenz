using Application.Features.Form.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Users.UserRegisterCommand;
using Application.Features.Users.UserLoginCommand;
using Application.Features.Users.CreateAccessTokenByRefreshToken;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("TokenAuth")]
        public async Task<IActionResult> CreateAccessTokenByRefreshToken(CreateAccessTokenByRefreshTokenRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
