using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Authentication.Queries.Login;
using Application.Common.Errors;
using Contracts.Common.Authentication.Requests;
using Contracts.Common.Authentication.Responses;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[ErrorHandlingFilter]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<RegisterResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("[action]")]
        public async  Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<LoginResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}
