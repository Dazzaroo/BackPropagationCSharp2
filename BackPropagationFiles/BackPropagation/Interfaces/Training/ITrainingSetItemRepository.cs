using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public interface ITrainingSetItemRepository
    {
        double GetInputNodeValue(int inputNo);

        double GetOutputNodeValue(int outputNo);

    }
}
