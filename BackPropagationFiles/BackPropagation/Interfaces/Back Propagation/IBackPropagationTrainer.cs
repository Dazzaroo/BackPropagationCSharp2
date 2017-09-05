using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace BackPropagation
{
    public interface IBackPropagationTrainer
    {
        ErrorMeasure FeedForwardPassTrain(ITrainingSetItemRepository trainingSetItem);
        void FeedForwardTrain();
    }
}
