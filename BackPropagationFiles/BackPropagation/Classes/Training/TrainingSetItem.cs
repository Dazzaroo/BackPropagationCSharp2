using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class TrainingSetItem : ITrainingSetItemRepository
    {
        double[] inputs;
        double[] outputs;

        public TrainingSetItem(double[] inputs, double[] outputs)
        {
            this.inputs = inputs;
            this.outputs = outputs;
        }

        public double GetInputNodeValue(int inputNo)
        {
            return inputs[inputNo];
        }

        public double GetOutputNodeValue(int outputNo)
        {
            return outputs[outputNo];
        }


    }
}
