using Assisticant;
using DecisionTree.Models;
using DecisionTree.Models.Nodes;
using DecisionTree.Models.Paths;
using DecisionTree.ViewModels.Details;

namespace DecisionTree.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private Root _root;
		private Selection _selection;

        public ViewModelLocator()
        {
			if (DesignMode)
				_root = LoadDesignModeDocument();
			else
				_root = LoadDocument();
			_selection = new Selection();
        }

        public object Main
        {
            get { return ViewModel(() => new MainViewModel(_root, _selection)); }
        }

		public object Detail
		{
			get
			{
				return ViewModel(() => _selection.SelectedPath == null
					? null
					: PathViewModel.ForPath(_selection.SelectedPath));
			}
		}

		private Root LoadDocument()
		{
			// TODO: Load your document here.
            return LoadDesignModeDocument();
		}

		private Root LoadDesignModeDocument()
		{
            var success = new OutcomeNode { Label = "Success" }
                .SetExpectedValue(50000.0f);
            var failure = new OutcomeNode { Label = "Failure" }
                .SetExpectedValue(0.0f);

            var uninformed = new ProbabilityNode()
                .AddChance(0.30f, success)
                .AddChance(0.70f, failure);
            uninformed.Label = "Uninformed";
            var informed = new ProbabilityNode()
                .AddChance(0.60f, success)
                .AddChance(0.40f, failure);
            informed.Label = "Informed";

            var marketResearch = new ChoiceNode()
                .AddOption(3000.0f, informed)
                .AddOption(0.0f, uninformed);
            marketResearch.Label = "Market Research";

            return new Root
            {
                Child = marketResearch
            };
        }
    }
}
