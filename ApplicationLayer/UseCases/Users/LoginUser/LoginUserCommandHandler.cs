using ApplicationLayer.Interfaces.Repositories;
using ApplicationLayer.Interfaces.Services;
using ApplicationLayer.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResultDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        
        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        public async Task<AuthResultDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.LoginDto;
            var user = await _userRepository.GetByUserNameAsync(dto.UserName);

            if (!user.IsEmailConfirmed)
            {
                throw new InvalidOperationException("Email not yet confirmed. Please check your email for confirmation link.");
            }

            if (user == null || !_passwordHasher.VerifyPassword(dto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
            var tokenJwt = await _jwtTokenGenerator.GenerateToken(user);

            return new AuthResultDto(tokenJwt, user.Id, user.UserName);
           
        }
    }
   
}
