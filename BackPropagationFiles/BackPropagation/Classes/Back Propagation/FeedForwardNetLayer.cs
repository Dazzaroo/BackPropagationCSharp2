using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public class FeedForwardNetLayer : IFeedForwardNetLayerRepository
    {
        double[,] layerWeights;
        double[,] layerWeightsChange;
        double[] toUnitBias;
        double[] toUnitBiasChange;
        double[] toUnitActivation;
        double[] fromUnitActivation;
        double[] toUnitDelta;

        int fromUnitCount;
        int toUnitCount;

        private static Random random = new Random(DateTime.Now.Second);

        public FeedForwardNetLayer(int fromUnitCount, int toUnitCount)
        {
            this.fromUnitCount = fromUnitCount;
            this.toUnitCount = toUnitCount;
            layerWeights = new double[fromUnitCount, toUnitCount];
            layerWeightsChange = new double[fromUnitCount, toUnitCount];
            toUnitBias = new double[toUnitCount];
            toUnitBiasChange = new double[toUnitCount];
            toUnitActivation = new double[toUnitCount];
            fromUnitActivation = new double[fromUnitCount];
            toUnitDelta = new double[toUnitCount];
        }

        double GetRandomWeight(double maxInitWeight)
        {
            double randomWeight = ((random.NextDouble() * maxInitWeight * 2) - maxInitWeight);
            return randomWeight;
        }
        public  void Randomize(double maxInitWeight)
        {
            for (int toNo = 0; toNo < toUnitCount; toNo++)
            {
                for (int fromNo = 0; fromNo < fromUnitCount; fromNo++)
                {
                    layerWeights[fromNo, toNo] = GetRandomWeight(maxInitWeight);
                }
                toUnitBias[toNo] = GetRandomWeight(maxInitWeight);
            }
        }

        public double GetToUnitDelta(int toNo)
        {
            return toUnitDelta[toNo];
        }

        public void SetToUnitDelta(int toNo, double deltaValue)
        {
            toUnitDelta[toNo] = deltaValue;
        }

        public double GetToUnitActivation(int toNo)
        {
            return toUnitActivation[toNo];
        }

        public void SetToUnitActivation(int toNo, double activationValue)
        {
            toUnitActivation[toNo] = activationValue;
        }
        public double GetFromUnitActivation(int fromNo)
        {
            return fromUnitActivation[fromNo];
        }

        public void SetFromUnitActivation(int fromNo, double activationValue)
        {
            fromUnitActivation[fromNo] = activationValue;
        }
        public int GetFromUnitCount()
        {
            return fromUnitCount;
        }

        public int GetToUnitCount()
        {
            return toUnitCount;
        }

        public double GetLayerWeight(int fromNo, int toNo)
        {
            return layerWeights[fromNo,toNo];
        }

        public double GetLayerWeightChange(int fromNo, int toNo)
        {
            return layerWeightsChange[fromNo, toNo];
        }

        public double GetLayerBias(int toNo)
        {
            return toUnitBias[toNo];
        }

        public double GetLayerBiasChange(int toNo)
        {
            return toUnitBiasChange[toNo];
        }

        public void SetLayerWeight(int fromNo, int toNo, double weightValue)
        {
            layerWeights[fromNo, toNo] = weightValue;
        }

        public void SetLayerWeightChange(int fromNo, int toNo, double weightValue)
        {
            layerWeightsChange[fromNo, toNo] = weightValue;
        }

        public void SetLayerBias(int toNo, double biasValue)
        {
            toUnitBias[toNo] = biasValue;
        }

        public void SetLayerBiasChange(int toNo, double biasValue)
        {
            toUnitBiasChange[toNo] = biasValue;
        }

        public void AddLayerWeight(int fromNo, int toNo, double weightChange)
        {
            layerWeights[fromNo, toNo] += weightChange;
        }

        public void AddLayerBias(int toNo, double biasChange)
        {
            toUnitBias[toNo] += biasChange;
        }
    }
}
