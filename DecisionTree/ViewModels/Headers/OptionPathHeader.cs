using DecisionTree.Models;
using DecisionTree.Models.Paths;
using System;

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

        public override Path Path
        {
            get { return _option; }
        }

        public string Cost
        {
            get { return String.Format("{0:#,0}", _option.Cost); }
        }
    }
}
