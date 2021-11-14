//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.records
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct DefRelations : ILineRelations<DefRelations>
    {
        public const string TableId = "llvm.defs.relations";

        public const byte FieldCount = 3;

        public LineNumber SourceLine;

        public Identifier Name;

        public Lineage Ancestors;

        public bool HasAncestor
        {
            [MethodImpl(Inline)]
            get => Ancestors.HasAncestor;
        }

        LineNumber ILineRelations.SourceLine
            => SourceLine;

        Identifier ILineRelations.Name
            => Name;

        public void Specify(LineNumber line, Identifier name, Lineage ancestors)
        {
            SourceLine = line;
            Name = name;
            Ancestors = ancestors;
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{14,64,1};
    }
}