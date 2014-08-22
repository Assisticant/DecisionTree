using DecisionTree.Models.Paths;
using System;

namespace DecisionTree.ViewModels.Details
{
    public abstract class PathViewModel
    {
        public abstract Path Path { get; }

        public NodeViewModel Node
        {
            get { return NodeViewModel.ForNode(Path.Child); }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PathViewModel that = obj as PathViewModel;
            if (that == null)
                return false;
            return Object.Equals(this.Path, that.Path);
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

        public static PathViewModel ForPath(Path path)
        {
            return
                Map<Root>  (path, r => new RootPathViewModel  (r)) ??
                Map<Option>(path, o => new OptionPathViewModel(o)) ??
                Map<Chance>(path, c => new ChancePathViewModel(c));
        }

        private static PathViewModel Map<TPath>(Path path, Func<TPath, PathViewModel> ctor)
            where TPath: Path
        {
            var specificPath = path as TPath;
            if (specificPath != null)
                return ctor(specificPath);
            else
                return null;
        }
    }
}
