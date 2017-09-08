using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    public interface IFeedForwardNetRepository
    {
        void AddLayer(FeedForwardNetLayer layer);

        FeedForwardNetLayer GetLayer(int layerNo);

        int LayerCount();

        bool IsFirstLayer(int currentLayerNo);

        bool IsLastLayer(int currentLayerNo);

        FeedForwardNetLayer GetOutputLayer();

        void FeedForwardPass(ISquashFunction squashFunction, ITrainingSetItemRepository trainingSetItem);

        void ShowWeights();



    }
}
