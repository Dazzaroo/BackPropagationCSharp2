using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    public class BackPropagationTrainer : IBackPropagationTrainer
    {
        private IFeedForwardNetRepository feedForwardNet;  /* care needed as this a copy ? */ 
        private IBackPropagationConstants backPropagationConstants;
        private ISquashFunction squashFunction;
        private ITrainingSetRepository trainingSet;
        private IHiddenLayerWeightChangeStrategy hiddenUnitWeightStrategy;
        private IOutputLayerWeightChangeStrategy outputUnitWeightStrategy;


        public ErrorMeasure FeedForwardPassTrain(ITrainingSetItemRepository trainingSetItem)
    
        {
            ErrorMeasure errorMeasure;
            feedForwardNet.FeedForwardPass(squashFunction, trainingSetItem);
            errorMeasure = ForwardPassError(trainingSetItem);
            UpdateNetworkAfterTrainingItem(trainingSetItem);

            return (errorMeasure);
        }

        public void UpdateNetworkAfterTrainingItem(ITrainingSetItemRepository trainingSetItem)
        {
            UpdateDeltas(trainingSetItem);
            UpdateWeights(trainingSetItem);
        }

        public void UpdateDeltas(ITrainingSetItemRepository trainingSetItem)
        {
           IFeedForwardNetLayerRepository previousLayer = null;
           for (int layerNo = feedForwardNet.LayerCount() - 1; layerNo >=0;  layerNo--)
            {
                IFeedForwardNetLayerRepository currentLayer = feedForwardNet.GetLayer(layerNo);
                if (feedForwardNet.IsLastLayer(layerNo))
                {
                    outputUnitWeightStrategy.UpdateWeightsDeltas(ref currentLayer, trainingSetItem);
                } else
                {
                    hiddenUnitWeightStrategy.UpdateWeightsDeltas(ref currentLayer, previousLayer);
                }
                previousLayer = currentLayer;
            }
        }

        public void UpdateWeights(ITrainingSetItemRepository trainingSetItem)
        {
            IFeedForwardNetLayerRepository previousLayer = null;
            for (int layerNo = feedForwardNet.LayerCount() - 1; layerNo >= 0; layerNo--)
            {
                IFeedForwardNetLayerRepository currentLayer = feedForwardNet.GetLayer(layerNo);
                if (feedForwardNet.IsLastLayer(layerNo))
                {
                    outputUnitWeightStrategy.UpdateWeights(ref currentLayer);
                }
                else
                {
                    hiddenUnitWeightStrategy.UpdateWeights(ref currentLayer);
                }
                previousLayer = currentLayer;
            }
        }

        public void FeedForwardTrain()
        {
            Boolean hasLearned = false;
            ErrorMeasure errorMeasure;
            double totalError;
            int iterationsCount = 0;
            while (!hasLearned && iterationsCount < backPropagationConstants.MaxIterations)
            {
                totalError = 0.0;
                hasLearned = true;
                iterationsCount++;
                foreach(ITrainingSetItemRepository trainingSetItem in trainingSet )
                {
                    errorMeasure = FeedForwardPassTrain(trainingSetItem);
                    totalError += errorMeasure.Error;
                    if (!errorMeasure.HasLearned)
                        hasLearned = false;
                }
            }

        }


        ErrorMeasure ForwardPassError(ITrainingSetItemRepository trainingSetItem)
         {
             ErrorMeasure errorMeasure;
             double sumError = 0.0;
             double localError;
             Boolean hasLearned = true;

             FeedForwardNetLayer outputLayer = feedForwardNet.GetOutputLayer();
             for (int outputNo =0; outputNo < outputLayer.GetToUnitCount(); outputNo++)
             {
                localError = Math.Abs(trainingSetItem.GetOutputNodeValue(outputNo) - outputLayer.GetToUnitActivation(outputNo));
                if (localError > backPropagationConstants.OutputTolerance)
                    hasLearned = false;
                sumError += localError;
             }
            errorMeasure = new ErrorMeasure(hasLearned, sumError);
            return (errorMeasure);
         }

        public BackPropagationTrainer(IFeedForwardNetRepository feedForwardNet, IBackPropagationAlgorithm backPropagationAlgorithm, ITrainingSetRepository trainingSet ) 
        
           :  this(feedForwardNet,
                                   backPropagationAlgorithm.BackPropagationConstants,
                                   backPropagationAlgorithm.SquashFunction,
                                   trainingSet,
                                   backPropagationAlgorithm.HiddenLayerWeightChangeStrategy,
                                   backPropagationAlgorithm.OutputLayerWeightChangeStrategy
                                  )
        {
        }

        public BackPropagationTrainer(IFeedForwardNetRepository feedForwardNet, IBackPropagationConstants backPropagationConstants, ISquashFunction squashFunction,
                                ITrainingSetRepository trainingSet,
                                IHiddenLayerWeightChangeStrategy hiddenUnitWeightStrategy,
                                IOutputLayerWeightChangeStrategy outputUnitWeightStrategy)
        {
            this.feedForwardNet = feedForwardNet;
            this.backPropagationConstants = backPropagationConstants;
            this.squashFunction = squashFunction;
            this.trainingSet = trainingSet;
            this.hiddenUnitWeightStrategy = hiddenUnitWeightStrategy;
            this.outputUnitWeightStrategy = outputUnitWeightStrategy;
        }

    }
}
