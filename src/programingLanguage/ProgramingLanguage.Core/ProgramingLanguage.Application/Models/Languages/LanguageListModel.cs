using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Models.Languages
{
    public class LanguageListModel : BasePageableModel
    {
        public IList<LanguageViewModel> Items { get; set; }

    }
}
