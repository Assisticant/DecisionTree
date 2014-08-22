using Assisticant.Collections;
using Assisticant.Fields;
using DecisionTree.Models.Paths;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTree.Models.Nodes
{
    public class ProbabilityNode : Node
    {
        private ObservableList<Chance> _chances = new ObservableList<Chance>();
        private Computed<float> _expectedValue;

        public ProbabilityNode()
        {
            _expectedValue = new Computed<float>(() =>
            {
                var denominator = _chances.Sum(p => p.Weight);
                var numerator = _chances.Sum(p => p.Weight * p.Child.ExpectedValue);
                return numerator / denominator;
            });
        }

        public ProbabilityNode AddChance(float weight, Node child)
        {
            _chances.Add(new Chance
            {
                Weight = weight,
                Child = child
            });
            return this;
        }

        public override float ExpectedValue
        {
            get { return _expectedValue.Value; }
        }

        public override IEnumerable<Path> Paths
        {
            get { return _chances; }
        }
    }
}
