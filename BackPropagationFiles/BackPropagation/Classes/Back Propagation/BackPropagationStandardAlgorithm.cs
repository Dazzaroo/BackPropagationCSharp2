using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation
{
    public class BackPropagationStandardAlgorithm : IBackPropagationAlgorithm
    {
        ISquashFunction squashFunction;
        IHiddenLayerWeightChangeStrategy hiddenLayerWeightChangeStrategy;
        IOutputLayerWeightChangeStrategy outputLayerWeightChangeStrategy;
        IBackPropagationConstants backPropagationConstants;

        public ISquashFunction SquashFunction { get => squashFunction; set => squashFunction = value; }
        public IOutputLayerWeightChangeStrategy OutputLayerWeightChangeStrategy { get => outputLayerWeightChangeStrategy; set => outputLayerWeightChangeStrategy = value; }
        public IHiddenLayerWeightChangeStrategy HiddenLayerWeightChangeStrategy { get => hiddenLayerWeightChangeStrategy; set => hiddenLayerWeightChangeStrategy = value; }
        public IBackPropagationConstants BackPropagationConstants { get => backPropagationConstants; set => backPropagationConstants = value; }

        public BackPropagationStandardAlgorithm(IBackPropagationConstants backPropagationConstants)
        {
            squashFunction = new ExpSquash();
            this.backPropagationConstants = backPropagationConstants;
            hiddenLayerWeightChangeStrategy = new HiddenUnitWeightChangeStrategyExp(backPropagationConstants);
            outputLayerWeightChangeStrategy = new OutputUnitWeightChangeStrategyExp(backPropagationConstants);
            
        }
    }
}
