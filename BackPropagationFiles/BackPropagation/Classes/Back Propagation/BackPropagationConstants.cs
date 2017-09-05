using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    class BackPropagationConstants : IBackPropagationConstants
    {
        private double learningRate;

        public double LearningRate { get => learningRate; set => learningRate = value; }
        public double Momentum { get => momentum; set => momentum = value; }
        public double MaxInitWeight { get => maxInitWeight; set => maxInitWeight = value; }
        public double OutputTolerance { get => outputTolerance; set => outputTolerance = value; }
        public int    MaxIterations { get => maxIterations; set => maxIterations = value; }

        private double momentum;

        private double maxInitWeight;

        private double outputTolerance;

        private int maxIterations;

        public BackPropagationConstants(double learningRate, double momentum, double maxInitWeight, double outputTolerance, int maxIterations)
        {
            this.learningRate = learningRate;
            this.momentum = momentum;
            this.maxInitWeight = maxInitWeight;
            this.outputTolerance = outputTolerance;
            this.maxIterations = maxIterations;
        }
    }
}
