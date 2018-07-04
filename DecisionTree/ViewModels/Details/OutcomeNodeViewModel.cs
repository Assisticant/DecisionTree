using DecisionTree.Models.Nodes;

namespace DecisionTree.ViewModels.Details
{
    public class OutcomeNodeViewModel : NodeViewModel
    {
        private readonly OutcomeNode _node;

        public OutcomeNodeViewModel(OutcomeNode node)
        {
            _node = node;
        }

        public float ExpectedValue
        {
            get => _node.ExpectedValue;
            set => _node.SetExpectedValue(value);
        }

        public override Node Node => _node;
    }
}
