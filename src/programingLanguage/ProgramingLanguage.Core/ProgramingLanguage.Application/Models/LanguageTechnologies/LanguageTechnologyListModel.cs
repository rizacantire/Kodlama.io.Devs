using Core.Persistence.Paging;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguageTechnology.Application.Models.LanguageTechnologyis
{
    public class LanguageTechnologyListModel : BasePageableModel
    {
        public IList<LanguageTechnologyViewModel> Items { get; set; }

    }
}
