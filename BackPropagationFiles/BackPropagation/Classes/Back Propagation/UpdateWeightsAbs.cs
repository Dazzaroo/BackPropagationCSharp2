using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    abstract class UpdateWeightsAbs
    {
        IBackPropagationConstants backPropagationConstants;

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
        public UpdateWeightsAbs(IBackPropagationConstants backPropagationConstants)
        {
            this.backPropagationConstants = backPropagationConstants;
        }
    }
}
