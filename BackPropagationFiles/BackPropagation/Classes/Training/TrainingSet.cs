using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class TrainingSet : ITrainingSetRepository
    {
        List<TrainingSetItem> trainingSet = new List<TrainingSetItem>();

        public int RecordCount {
            get {
                return trainingSet.Count;
            }
        }

        public void AddTrainingSetItem(ITrainingSetItemRepository trainingSetItem)
        {
            trainingSet.Add((TrainingSetItem)trainingSetItem);
        }

        public ITrainingSetItemRepository GetTrainingSetItem(int recordNo)
        {
            return trainingSet[recordNo];
        }

       IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (ITrainingSetItemRepository trainingSetItem in trainingSet)
            {
                yield return trainingSetItem;
            }
        }

        public IEnumerator<ITrainingSetItemRepository> GetEnumerator()
        {
            foreach (ITrainingSetItemRepository trainingSetItem in trainingSet)
            {
                yield return trainingSetItem;
            }
        }

        public TrainingSet(double[][] inputs, double[][] outputs)
        {
            if (inputs.GetLength(0) != outputs.GetLength(0))
                throw new System.ArgumentException("inputs and output arrays must match in size");

            for (int i=0; i< inputs.GetLength(0); i++)
            {
                AddTrainingSetItem(new TrainingSetItem(inputs[i], outputs[i]));
            }
        }

    }
}
