//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ClassRelations : ILineRelations<ClassRelations>
    {
        public const string TableId = "llvm.classes.relations";

        public const byte FieldCount = 4;

        [Render(14)]
        public LineNumber SourceLine;

        [Render(60)]
        public Identifier Name;

        [Render(110)]
        public Lineage Ancestors;

        [Render(1)]
        public string Parameters;

        LineNumber ILineRelations.SourceLine
            => SourceLine;

        Identifier ILineRelations.Name
            => Name;
    }
}