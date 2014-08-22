using Assisticant.Fields;
using DecisionTree.Models.Nodes;

namespace DecisionTree.Models.Paths
{
    public class Chance : Path
    {
        private Observable<float> _weight = new Observable<float>();

        public float Weight
        {
            get { return _weight; }
            set { _weight.Value = value; }
        }
    }
}
