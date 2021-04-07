using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class SmarthPhone : ICall, IBrowse
    {
        public string Calling(string number)
        {
            if (number.Any(c => !char.IsDigit(c)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            return $"Calling... {number}";
        }
        public string Browsing(string website)
        {
            if (website.Any(c => char.IsDigit(c)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            return $"Browsing: {website}!";
        }
    }
}
