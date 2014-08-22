using DecisionTree.Models.Nodes;
using Assisticant.Fields;

namespace DecisionTree.Models.Paths
{
    public abstract class Path
    {
        private Observable<Node> _child = new Observable<Node>();

        public Node Child
        {
            get { return _child; }
            set { _child.Value = value; }
        }
    }
}
