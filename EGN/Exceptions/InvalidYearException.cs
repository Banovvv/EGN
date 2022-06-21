using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGN.Exceptions
{
    public class InvalidYearException : Exception
    {
        private const int _startYear = 1800;
        private const int _endYear = 2099;
        private static readonly string _message = $"Годината на раждане трябва да е между {_startYear} и {_endYear}";

        public InvalidYearException() : base(_message)
        {
            
        }
    }
}
