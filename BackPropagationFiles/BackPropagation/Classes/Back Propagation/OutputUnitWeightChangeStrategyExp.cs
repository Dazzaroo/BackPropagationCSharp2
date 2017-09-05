using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    class OutputUnitWeightChangeStrategyExp : IOutputLayerWeightChangeStrategy
    {
        IBackPropagationConstants backPropagationConstants;

        public void UpdateWeightsDeltas(ref IFeedForwardNetLayerRepository currentLayer, ITrainingSetItemRepository trainingSetItem)
        {
            CalculateDeltas(ref currentLayer, trainingSetItem);
            UpdateWeights(ref currentLayer);
        }

        public void CalculateDeltas(ref IFeedForwardNetLayerRepository currentLayer, ITrainingSetItemRepository trainingSetItem)
        {
            double outputDelta;

            for (int toNo = 0; toNo < currentLayer.GetToUnitCount(); toNo++)
            {
                double outputActivation = currentLayer.GetToUnitActivation(toNo);
                outputDelta = (trainingSetItem.GetOutputNodeValue(toNo) - outputActivation) * outputActivation * (1 - outputActivation);
                currentLayer.SetToUnitDelta(toNo, outputDelta);
            }
        }

        public void UpdateWeights(ref IFeedForwardNetLayerRepository currentLayer)
        {
            for (int toNo = 0; toNo < currentLayer.GetToUnitCount(); toNo++)
            {
                for (int fromNo = 0; fromNo < currentLayer.GetFromUnitCount(); fromNo++)
                {
                    double weightChange = backPropagationConstants.LearningRate * currentLayer.GetToUnitDelta(toNo) +
                                          currentLayer.GetLayerWeightChange(fromNo, toNo) * backPropagationConstants.Momentum;
                    currentLayer.SetLayerWeightChange(fromNo, toNo, weightChange);
                    currentLayer.AddLayerWeight(fromNo, toNo, weightChange);
                }
                double biasChange = backPropagationConstants.LearningRate * currentLayer.GetToUnitDelta(toNo) + currentLayer.GetLayerBiasChange(toNo) * backPropagationConstants.Momentum;
                currentLayer.SetLayerBiasChange(toNo, biasChange);
                currentLayer.AddLayerBias(toNo, biasChange);
            }
        }

        public OutputUnitWeightChangeStrategyExp(IBackPropagationConstants backPropagationConstants)
        {
            this.backPropagationConstants = backPropagationConstants;
        }
   
    }
}
