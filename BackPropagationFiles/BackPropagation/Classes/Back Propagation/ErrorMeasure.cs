using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public class ErrorMeasure
    {
        bool hasLearned;
        double error;

        public bool HasLearned { get => hasLearned; }
        public double Error { get => error; }

        public ErrorMeasure(bool hasLearned, double error)
        {
            this.hasLearned = hasLearned;
            this.error = error;
        }
        
    }
}
