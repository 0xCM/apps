//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.records
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ClassRelations : ILineRelations<ClassRelations>
    {
        public const string TableId = "llvm.classes.relations";

        public const byte FieldCount = 4;

        public LineNumber SourceLine;

        public Identifier Name;

        public Lineage Ancestors;

        public string Parameters;

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
            => new byte[FieldCount]{14,60,110,1};
    }
}