using DecisionTree.Models.Nodes;
using System;

namespace DecisionTree.ViewModels.Details
{
    public abstract class NodeViewModel
    {
        public abstract Node Node { get; }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            NodeViewModel that = obj as NodeViewModel;
            if (that == null)
                return false;
            return Object.Equals(this.Node, that.Node);
        }

        public override int GetHashCode()
        {
            return Node.GetHashCode();
        }

        public static NodeViewModel ForNode(Node node)
        {
            return Map<OutcomeNode>(node, o => new OutcomeNodeViewModel(o));
        }

        private static NodeViewModel Map<TNode>(Node node, Func<TNode, NodeViewModel> ctor)
            where TNode : Node
        {
            var specificNode = node as TNode;
            if (specificNode != null)
                return ctor(specificNode);
            else
                return null;
        }
    }
}
