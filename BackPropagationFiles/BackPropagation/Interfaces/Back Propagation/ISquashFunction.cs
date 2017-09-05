using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public interface ISquashFunction
    {
        double Squash(double value);
    }
}
