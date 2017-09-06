using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public interface IHiddenLayerWeightChangeStrategy
    {
        void UpdateWeightsDeltas(ref IFeedForwardNetLayerRepository currentLayer, IFeedForwardNetLayerRepository previousLayer);
        void UpdateWeights(ref IFeedForwardNetLayerRepository currentLayer);
    }
}
