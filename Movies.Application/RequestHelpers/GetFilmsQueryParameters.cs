using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.RequestHelpers
{
    public class GetFilmsQueryParameters : QueryParameters
    {
        public string Title { get; set; } = string.Empty;
    }
}
