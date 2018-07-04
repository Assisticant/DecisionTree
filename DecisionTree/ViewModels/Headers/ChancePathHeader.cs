using DecisionTree.Models;
using DecisionTree.Models.Paths;

namespace DecisionTree.ViewModels.Headers
{
    public class ChancePathHeader : PathHeader
    {
        private readonly Chance _chance;

        public ChancePathHeader(Chance chance, Selection selection) :
            base(selection)
        {
            _chance = chance;
        }

        public override Path Path => _chance;

        public string Weight => $"{_chance.Weight * 100.0f}%";
    }
}
