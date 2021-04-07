using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICall
    {
        public string Calling(string number)
        {
            if (number.Any(c => !char.IsDigit(c)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            return $"Dialing... {number}";
        }

    }
}
