using MediatR;


namespace ProgramingLanguage.Application.Features.Commands.LanguageTechnologyies.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
