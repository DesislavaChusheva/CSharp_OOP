using System;
using System.Collections.Generic;

namespace Telephony
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            SmarthPhone smarthPhone = new SmarthPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();


            foreach (var number in firstLine)
            {
                try
                {
                    string result = number.Length == 10 ? 
                        smarthPhone.Calling(number) : 
                        stationaryPhone.Calling(number);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in secondLine)
            {
                try
                {
                    Console.WriteLine(smarthPhone.Browsing(url));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }
    }
}
