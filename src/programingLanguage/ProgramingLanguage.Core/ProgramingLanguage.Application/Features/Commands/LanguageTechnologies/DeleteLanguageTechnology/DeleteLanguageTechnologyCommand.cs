using MediatR;


namespace ProgramingLanguageTechnology.Application.Features.Commands.LanguageTechnologyies.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
