using Assisticant.Fields;
using DecisionTree.Models.Paths;

namespace DecisionTree.Models
{
    public class Selection
    {
        private Observable<Path> _selectedPath = new Observable<Path>();

        public Path SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath.Value = value; }
        }
    }
}
