using DecisionTree.Models.Paths;

namespace DecisionTree.ViewModels.Details
{
    public class RootPathViewModel : PathViewModel
    {
        private readonly Root _root;

        public RootPathViewModel(Root root)
        {
            _root = root;            
        }

        public override Path Path
        {
            get { return _root; }
        }
    }
}
