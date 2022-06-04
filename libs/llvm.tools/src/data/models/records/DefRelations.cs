//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId)]
    public struct DefRelations : ILineRelations<DefRelations>, IComparable<DefRelations>
    {
        public const string TableId = "llvm.defs.relations";

        public const byte FieldCount = 3;

        [Render(14)]
        public LineNumber SourceLine;

        [Render(64)]
        public Identifier Name;

        [Render(1)]
        public Lineage Ancestors;

        LineNumber ILineRelations.SourceLine
            => SourceLine;

        Identifier ILineRelations.Name
            => Name;

        [MethodImpl(Inline)]
        public void Specify(LineNumber line, Identifier name, Lineage ancestors)
        {
            SourceLine = line;
            Name = name;
            Ancestors = ancestors ?? Lineage.Empty;
        }

        public string ParentName
            => LlvmData.parent(this);

        public ReadOnlySpan<string> AncestorNames
            => LlvmData.ancestors(this);

        public static DefRelations Empty
        {
            get
            {
                var dst = new DefRelations();
                dst.Specify(LineNumber.Empty, Identifier.Empty, Lineage.Empty);
                return dst;
            }
        }

        public int CompareTo(DefRelations src)
        {
            var i = Name.CompareTo(src.Name);
            if(i == 0)
                return ParentName.CompareTo(src.ParentName);
            else
                return i;
        }
    }
}