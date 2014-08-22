using DecisionTree.Models.Paths;

namespace DecisionTree.ViewModels.Details
{
    public class ChancePathViewModel : PathViewModel
    {
        private readonly Chance _chance;

        public ChancePathViewModel(Chance chance)
        {
            _chance = chance;            
        }

        public float Weight
        {
            get { return _chance.Weight; }
            set { _chance.Weight = value; }
        }

        public override Path Path
        {
            get { return _chance; }
        }
    }
}
