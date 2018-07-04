using DecisionTree.Models;
using DecisionTree.Models.Nodes;
using DecisionTree.Models.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTree.ViewModels.Headers
{
    public abstract class PathHeader
    {
        private readonly Selection _selection;

        public PathHeader(Selection selection)
        {
            _selection = selection;
        }

        public abstract Path Path { get; }

        public string Label => Path.Child.Label;

        public string ExpectedValue => $"{Path.Child.ExpectedValue:#,0.}";

        public bool Selected
        {
            get => Object.Equals(_selection.SelectedPath, Path);
            set
            {
                if (value)
                    _selection.SelectedPath = Path;
                else if (Object.Equals(_selection.SelectedPath, Path))
                    _selection.SelectedPath = null;
            }
        }

        public Node Node => Path.Child;

        public IEnumerable<PathHeader> Children =>
            from child in Path.Child.Paths
            select PathHeader.ForPath(child, _selection);

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PathHeader that = obj as PathHeader;
            if (that == null)
                return false;
            return Object.Equals(this.Path, that.Path);
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

        public static PathHeader ForPath(Path path, Selection selection)
        {
            return
                Map<Chance>(path, c => new ChancePathHeader(c, selection)) ??
                Map<Option>(path, o => new OptionPathHeader(o, selection)) ??
                Map<Root>  (path, r => new RootPathHeader  (r, selection));
        }

        private static PathHeader Map<TPath>(Path path, Func<TPath, PathHeader> ctor)
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
