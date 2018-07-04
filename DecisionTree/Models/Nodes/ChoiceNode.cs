using Assisticant.Collections;
using Assisticant.Fields;
using DecisionTree.Models.Paths;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTree.Models.Nodes
{
    public class ChoiceNode : Node
    {
        private ObservableList<Option> _options = new ObservableList<Option>();
        private Computed<float> _expectedValue;

        public ChoiceNode()
        {
            _expectedValue = new Computed<float>(() =>
                _options.Max(o => o.Child.ExpectedValue - o.Cost));
        }

        public ChoiceNode AddOption(float cost, Node child)
        {
            _options.Add(new Option { Cost = cost, Child = child });
            return this;
        }

        public override float ExpectedValue => _expectedValue.Value;

        public override IEnumerable<Path> Paths => _options;
    }
}
