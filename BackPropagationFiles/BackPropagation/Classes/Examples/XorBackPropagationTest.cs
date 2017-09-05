using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackPropagation;
using Training;

namespace BackPropagationTest
{
    /* Non-Linear seperable XOR network test */
    class XorBackPropagationTest
    {
        public void Run()
        {
            double[][] inputs =
            {
                new double[] {0, 0},
                new double[] {1, 0},
                new double[] {0, 1},
                new double[] {1, 1}
            };

            double[][] outputs =
           {
                new double[] {0},
                new double[] {1},
                new double[] {1},
                new double[] {0}
            };
            TrainingSet trainingSet = new TrainingSet(inputs, outputs);
            IBackPropagationConstants backPropagationConstants = new BackPropagationConstants(learningRate: 0.1, momentum: 0.9, maxInitWeight: 0.5, outputTolerance: 0.1, maxIterations: 10000  );
            FeedForwardNet xorNet = new FeedForwardNet(new int[] { 2, 2, 1 }, backPropagationConstants.MaxInitWeight);
            IBackPropagationAlgorithm backPropagationAlgorithm = new BackPropagationStandardAlgorithm(backPropagationConstants);
            IBackPropagationTrainer backPropagationTrainer = new BackPropagationTrainer(xorNet, backPropagationAlgorithm, trainingSet);
            backPropagationTrainer.FeedForwardTrain();


        }
    }
}
