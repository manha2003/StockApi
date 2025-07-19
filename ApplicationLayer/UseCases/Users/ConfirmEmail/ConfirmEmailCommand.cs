using MediatR;

namespace ApplicationLayer.UseCases.Users.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public ConfirmEmailCommand(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}