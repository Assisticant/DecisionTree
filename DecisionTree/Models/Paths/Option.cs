using Assisticant.Fields;

namespace DecisionTree.Models.Paths
{
    public class Option : Path
    {
        private Observable<float> _cost = new Observable<float>();

        public float Cost
        {
            get => _cost;
            set => _cost.Value = value;
        }
    }
}
