using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.BaseCommands
{
    public class UpdateCommand<T> :  IRequest<T> 
    {
        public int Id { get; set; }
    }
}
