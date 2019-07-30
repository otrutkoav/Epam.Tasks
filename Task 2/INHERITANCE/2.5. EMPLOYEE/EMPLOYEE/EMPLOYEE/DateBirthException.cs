using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE
{
    public class DateBirthException : Exception
    {
        public DateBirthException(string message) : base(message)
        {

        }
    }
}
