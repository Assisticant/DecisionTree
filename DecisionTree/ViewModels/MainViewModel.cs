using DecisionTree.Models;
using DecisionTree.Models.Paths;
using DecisionTree.ViewModels.Headers;
using System.Collections.Generic;

namespace DecisionTree.ViewModels
{
    public class MainViewModel
    {
        private readonly Path _root;
		private readonly Selection _selection;

        public MainViewModel(Path root, Selection selection)
        {
            _root = root;
			_selection = selection;
        }

        public IEnumerable<PathHeader> Nodes
        {
            get
            {
                yield return PathHeader.ForPath(_root, _selection);
            }
        }
    }
}
