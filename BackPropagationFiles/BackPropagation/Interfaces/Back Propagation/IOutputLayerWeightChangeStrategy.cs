using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    public interface IOutputLayerWeightChangeStrategy
    {
        void UpdateWeightsDeltas(ref IFeedForwardNetLayerRepository currentLayer, ITrainingSetItemRepository trainingSetItem);
        void UpdateWeights(ref IFeedForwardNetLayerRepository currentLayer);
    }
}
