using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces.Repositories;
using ApplicationLayer.Interfaces.Services;
using ApplicationLayer.Services;
using AutoMapper;
using DomainLayer.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper, IEmailService emailService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserDto;

            if (_userRepository.ExistsByEmail(dto.Email))
            {
                throw new Exception("User with this email already exists.");
            }

            if (_userRepository.ExistsByUserName(dto.UserName))
            {
                throw new Exception("User with this username already exists.");
            }

            var user = _mapper.Map<User>(dto);

            user.PasswordHash = _passwordHasher.HashPassword(dto.Password);
            
            user.EmailConfirmationToken = _emailService.GenerateEmailConfirmationToken();

           

            var mailRequest = new MailRequest
            {
                ToEmail = dto.Email,
                Subject = "Confirm your email for new account ",
                Body = "Update later" //this is where i include the confirmation link 
            };

            try
            {
                await _emailService.SendEmailAsync(mailRequest);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Failed to send confirmation email. Please try again later.", ex);
            }

            await _userRepository.AddAsync(user);
            return "User registered successfully.";
        }

    }
}
