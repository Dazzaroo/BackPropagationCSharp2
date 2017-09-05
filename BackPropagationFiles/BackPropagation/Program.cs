using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;
using BackPropagation;
using BackPropagationTest;

namespace BackPropagation
{
    class Program
    {
        static void Main(string[] args)
        {
            XorBackPropagationTest xorBackPropagationTest = new XorBackPropagationTest();
            xorBackPropagationTest.Run();
        }
    }
}
