using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{

        public interface IBackPropagationConstants
        {
            double LearningRate { get; set; }
            double Momentum { get; set; }
            double MaxInitWeight { get; set; }
            double OutputTolerance { get; set; }
            int    MaxIterations { get; set; }
        }
    
}
