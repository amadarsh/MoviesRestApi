using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.RequestHelpers
{
    public class QueryParameters
    {
        const int _maxSize = 10;
        private int _size = 5;

        public int Page { get; set; } = 1;
        public int Size { get { return _size; } set { _size = Math.Min(_maxSize, value); } }
    }
}
