using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    class ExpSquash : ISquashFunction
    {
        public double Squash(double value)
        {
            return (1 / (1 + Math.Exp(-value)));
        }
    }
}
