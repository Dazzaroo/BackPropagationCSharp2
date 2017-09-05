using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public interface IFeedForwardNetLayerRepository
    {
        int GetFromUnitCount();
        int GetToUnitCount();
        double GetLayerWeight(int fromNo, int toNo);
        void SetLayerWeight(int fromNo, int toNo, double weightValue);
        double GetLayerBias(int toNo);
        void SetLayerBias(int toNo, double biasValue);
        double GetToUnitDelta(int toNo);
        void SetToUnitDelta(int toNo, double deltaValue);
        double GetToUnitActivation(int toNo);
        void SetLayerWeightChange(int fromNo, int toNo, double weightValue);
        double GetLayerBiasChange(int toNo);
        void SetLayerBiasChange(int toNo, double biasValue);
        double GetLayerWeightChange(int fromNo, int toNo);
        void AddLayerWeight(int fromNo, int toNo, double weightChange);
        void AddLayerBias(int toNo, double biasChange);
        double GetFromUnitActivation(int fromNo);


    }
}
