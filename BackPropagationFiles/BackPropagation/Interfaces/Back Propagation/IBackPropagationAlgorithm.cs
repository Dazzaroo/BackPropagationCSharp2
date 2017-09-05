using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public interface IBackPropagationAlgorithm
    {
        ISquashFunction SquashFunction { get; set; }
        IOutputLayerWeightChangeStrategy OutputLayerWeightChangeStrategy { get; set; }
        IHiddenLayerWeightChangeStrategy HiddenLayerWeightChangeStrategy { get; set; }
        IBackPropagationConstants BackPropagationConstants { get; set; }
    }
}
