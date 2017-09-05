using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public interface ITrainingSetRepository : IEnumerable<ITrainingSetItemRepository>
    {
        int RecordCount { get; }
        void AddTrainingSetItem(ITrainingSetItemRepository trainingSetItem);
        ITrainingSetItemRepository GetTrainingSetItem(int recordNo);

    }
}
