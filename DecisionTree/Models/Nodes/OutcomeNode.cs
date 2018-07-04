using Assisticant.Fields;
using DecisionTree.Models.Paths;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTree.Models.Nodes
{
    public class OutcomeNode : Node
    {
        private Observable<float> _expectedValue = new Observable<float>(default(float));

        public override float ExpectedValue => _expectedValue;

        public OutcomeNode SetExpectedValue(float value)
        {
            _expectedValue.Value = value;
            return this;
        }

        public override IEnumerable<Path> Paths => Enumerable.Empty<Path>();
    }
}
