using Application.Features.Languages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Models
{
    public class GetListModel : BasePageableModel
    {
        public IList<GetListLanguageDto> Items { get; set; }
    }
}
