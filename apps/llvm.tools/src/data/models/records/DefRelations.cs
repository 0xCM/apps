//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct DefRelations : ILineRelations<DefRelations>
    {
        public static string parent(in DefRelations src)
            => src.Ancestors != null && src.Ancestors.IsNonEmpty ? src.Ancestors.Name : EmptyString;

        public static ReadOnlySpan<string> ancestors(in DefRelations src)
        {
            return src.Ancestors != null && src.Ancestors.IsNonEmpty
                ?  (src.Ancestors.HasAncestor
                        ? Arrays.concat(new string[]{src.Ancestors.Name}, src.Ancestors.Ancestors.Storage)
                        : new string[]{src.Ancestors.Name}
                        )
                : default;
        }

        public const string TableId = "llvm.defs.relations";

        public const byte FieldCount = 3;

        public LineNumber SourceLine;

        public Identifier Name;

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
            => parent(this);

        public ReadOnlySpan<string> AncestorNames
            => ancestors(this);

        public static DefRelations Empty
        {
            get
            {
                var dst = new DefRelations();
                dst.Specify(LineNumber.Empty, Identifier.Empty, Lineage.Empty);
                return dst;
            }
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{14,64,1};
    }
}