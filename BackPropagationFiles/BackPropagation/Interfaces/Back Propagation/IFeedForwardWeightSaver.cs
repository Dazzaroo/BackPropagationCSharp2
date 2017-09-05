using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    interface IFeedForwardWeightSaver
    {
        void SaveWeights(IFeedForwardNetRepository feedForwardNetRepository);
    }
}
