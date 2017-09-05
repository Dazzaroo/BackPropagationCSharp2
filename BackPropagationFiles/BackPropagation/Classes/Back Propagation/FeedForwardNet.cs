using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    class FeedForwardNet : IFeedForwardNetRepository
    {
        List<FeedForwardNetLayer> feedForwardNet = new List<FeedForwardNetLayer>();

        public FeedForwardNet(int[] nodeCountInLayers, double maxWeight)
        {
            if (nodeCountInLayers.Length < 3)
                throw new ArgumentException("Number of layers must be greater than or equal to three");
            for (int layerCount =0; layerCount < nodeCountInLayers.Length - 1; layerCount++)
            {
                int fromNodeCount = nodeCountInLayers[layerCount];
                int toNodeCount = nodeCountInLayers[layerCount + 1];
                feedForwardNet.Add(new FeedForwardNetLayer(fromNodeCount, toNodeCount));
            }
            Randomize(maxWeight);

        }
        public void Randomize(double maxInitWeight)
        {
            foreach (FeedForwardNetLayer feedForwardNetLayer in feedForwardNet) {
                feedForwardNetLayer.Randomize(maxInitWeight);
            }
        }
        public void AddLayer(FeedForwardNetLayer layer)
        {
            feedForwardNet.Add(layer);
        }

        public FeedForwardNetLayer GetLayer(int layerNo)
        {
            return feedForwardNet[layerNo];
        }

        public FeedForwardNetLayer GetOutputLayer()
        {
            return feedForwardNet[feedForwardNet.Count - 1];
        }

        public int LayerCount()
        {
            return feedForwardNet.Count;
        }

        public bool IsFirstLayer(int currentLayerNo)
        {
            return currentLayerNo == 0;
        }

        public bool IsLastLayer(int currentLayerNo)
        {
            return currentLayerNo == feedForwardNet.Count - 1;
        }

        public void FeedForwardPass(ISquashFunction squashFunction, ITrainingSetItemRepository trainingSetItem)
        {
            FeedForwardNetLayer currentLayer;
            FeedForwardNetLayer previousLayer;

            for (int currentLayerNo = 0; currentLayerNo < LayerCount(); currentLayerNo++)
            {
                currentLayer = GetLayer(currentLayerNo);
                if (currentLayerNo > 0)
                    previousLayer = GetLayer(currentLayerNo - 1);
                else
                    previousLayer = null;
        
                SetLayerActivation(ref currentLayer, trainingSetItem, previousLayer, currentLayerNo);

                CalculateNewLayerActivation(ref currentLayer, squashFunction);

            }
            //return ForwardPassError(trainingSetItem, currentLayerNo);
         }

        public void CalculateNewLayerActivation(ref FeedForwardNetLayer currentLayer, ISquashFunction squashFunction)
        {
            double weightSum;

            for (int toNo = 0; toNo < currentLayer.GetToUnitCount(); toNo++)
            {
                weightSum = 0.0;
                for (int fromNo = 0; fromNo < currentLayer.GetFromUnitCount(); fromNo++)
                {
                    weightSum += currentLayer.GetFromUnitActivation(fromNo) * currentLayer.GetLayerWeight(fromNo, toNo);
                }
                weightSum += currentLayer.GetLayerBias(toNo);
                currentLayer.SetToUnitActivation(toNo, squashFunction.Squash(weightSum));
            }
        }


        public void SetLayerActivation(ref FeedForwardNetLayer layer, ITrainingSetItemRepository trainingSetItem, FeedForwardNetLayer previousLayer, int currentLayerNo)
        {
  
            if (IsFirstLayer(currentLayerNo))
            {
                SetLayerActivationInput(ref layer, trainingSetItem);
            }
            else
            {
                SetLayerActivationHidden(ref layer, previousLayer);
            }
          
        }


        public void SetLayerActivationInput(ref FeedForwardNetLayer layer , ITrainingSetItemRepository trainingSetItem)
        {
            for (int fromNo=0; fromNo < layer.GetFromUnitCount(); fromNo++)
            {
                layer.SetFromUnitActivation(fromNo, trainingSetItem.GetInputNodeValue(fromNo));
            }
        }

        public void SetLayerActivationHidden(ref FeedForwardNetLayer layer, FeedForwardNetLayer previousLayer)
        {
            for (int fromNo = 0; fromNo < layer.GetFromUnitCount(); fromNo++)
            {
                layer.SetFromUnitActivation(fromNo, previousLayer.GetToUnitActivation(fromNo));
            }
        }
    }
}
