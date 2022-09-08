using Application.Models.Register;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredModel>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

    }
}