using DecisionTree.Models.Paths;

namespace DecisionTree.ViewModels.Details
{
    public class OptionPathViewModel : PathViewModel
    {
        private readonly Option _option;

        public OptionPathViewModel(Option option)
        {
            _option = option;            
        }

        public float Cost
        {
            get => _option.Cost;
            set => _option.Cost = value;
        }

        public override Path Path => _option;
    }
}
