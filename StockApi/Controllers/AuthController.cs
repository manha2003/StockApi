using ApplicationLayer.DTOs.User;
using ApplicationLayer.Interfaces.Repositories;
using ApplicationLayer.UseCases.Users.ConfirmEmail;
using ApplicationLayer.UseCases.Users.LoginUser;
using ApplicationLayer.UseCases.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApi.Responses;

namespace StockApi.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var command = new RegisterUserCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(ApiResponse<string>.SuccessResponse(result, "User registered successfully"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var command = new LoginUserCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(ApiResponse<AuthResultDto>.SuccessResponse(result, "User login successfully"));

        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, [FromQuery] string token)
        {
            var result = await _mediator.Send(new ConfirmEmailCommand(email,token));
            if (!result)
            {
                return BadRequest("Invalid or expired token.");
            }

            return Ok("Email confirmed successfully.");
        }


    }
}
