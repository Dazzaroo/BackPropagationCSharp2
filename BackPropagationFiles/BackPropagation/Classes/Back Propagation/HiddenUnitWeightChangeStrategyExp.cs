using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    class HiddenUnitWeightChangeStrategyExp :  UpdateWeightsAbs, IHiddenLayerWeightChangeStrategy
    {
     

        public void UpdateWeightsDeltas(ref IFeedForwardNetLayerRepository currentLayer, IFeedForwardNetLayerRepository previousLayer)
        {
            CalculateDeltas(ref currentLayer, previousLayer);
            UpdateWeights(ref currentLayer);
        }

        public void CalculateDeltas(ref IFeedForwardNetLayerRepository currentLayer, IFeedForwardNetLayerRepository previousLayer)
        {
            double[] hiddenDSum = new double[currentLayer.GetFromUnitCount()];
            for (int fromNo = 0; fromNo < currentLayer.GetFromUnitCount(); fromNo++)
            {
                hiddenDSum[fromNo] = 0.0;
                for (int toNo = 0; toNo < previousLayer.GetToUnitCount(); toNo++)
                {
                    hiddenDSum[fromNo] += previousLayer.GetToUnitDelta(toNo) * currentLayer.GetLayerWeight(fromNo, toNo);
                }
                double fromUnitActivation = previousLayer.GetFromUnitActivation(fromNo);
                double hiddenDelta = fromUnitActivation * (1 - fromUnitActivation) * hiddenDSum[fromNo];
                currentLayer.SetToUnitDelta(fromNo, hiddenDelta);
        
            }
        }


       /* public void UpdateWeights(ref IFeedForwardNetLayerRepository currentLayer)
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
        }*/

        public HiddenUnitWeightChangeStrategyExp(IBackPropagationConstants backPropagationConstants) : base(backPropagationConstants)
        {
          //  this.backPropagationConstants = backPropagationConstants;
        }

    }
}


