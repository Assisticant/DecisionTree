using Assisticant.Fields;
using DecisionTree.Models.Paths;
using System.Collections.Generic;

namespace DecisionTree.Models.Nodes
{
    public abstract class Node
    {
        private Observable<string> _label = new Observable<string>();

        public string Label
        {
            get { return _label; }
            set { _label.Value = value; }
        }


        public abstract float ExpectedValue { get; }
        public abstract IEnumerable<Path> Paths { get; }
    }
}
