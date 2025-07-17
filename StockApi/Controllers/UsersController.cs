using ApplicationLayer.UseCases.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApi.Responses;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(ApiResponse<string>.SuccessResponse(result, "User registered successfully"));
        }

    }
}
