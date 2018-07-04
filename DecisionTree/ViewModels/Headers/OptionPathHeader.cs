using DecisionTree.Models;
using DecisionTree.Models.Paths;

namespace DecisionTree.ViewModels.Headers
{
    public class OptionPathHeader : PathHeader
    {
        private readonly Option _option;

        public OptionPathHeader(Option option, Selection selection)
            : base(selection)
        {
            _option = option;            
        }

        public override Path Path => _option;

        public string Cost => $"{_option.Cost:#,0}";
    }
}
