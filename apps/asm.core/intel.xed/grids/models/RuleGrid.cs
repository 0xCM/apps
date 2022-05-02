//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleGrid
        {
            public readonly RuleSig Rule;

            public readonly ushort RowCount;

            public readonly byte ColCount;

            public readonly Index<GridCell> Cells;

            public readonly ushort FieldCount;

            public readonly FS.FileUri TablePath;

            [MethodImpl(Inline)]
            public RuleGrid(RuleSig sig, ushort rows, byte cols, Index<GridCell> src)
            {
                Rule = sig;
                RowCount = rows;
                ColCount = cols;
                Cells = src;
                FieldCount = Require.equal((ushort)(rows*cols), (ushort)src.Count);
                TablePath = XedPaths.Service.CheckedTableDef(sig);
            }

            public void Render(ITextEmitter dst)
                => render(this,dst);

            public string Format()
            {
                var dst = text.buffer();
                Render(dst);
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}