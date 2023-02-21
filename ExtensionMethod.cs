using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static internal class ExtensionMethod
    {
        public static int GetDigit(this int num)
        {
            int count = 0;
            while (num != 0)
            {
                num /= 10;
                count++;
            }
            return count;
        }
    }
}
