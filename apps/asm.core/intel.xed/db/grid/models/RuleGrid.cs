//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules.RuleGrids;

    partial class XedRules
    {
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
            {
                const string RowRenderPattern = "{0,-32} | {1,-6} | {2,-3} | {3,-5} | {4,-24}";

                var k=0;
                var data = Cells.View;

                dst.AppendLine(string.Format("{0,-32} {1}", Rule.Format(), TablePath));
                dst.AppendLine(RP.PageBreak260);
                for(var i=0; i<RowCount; i++)
                {
                    var offset = i*ColCount;
                    var cells = slice(data, offset, ColCount);
                    var count = Require.equal(cells.Length, ColCount);
                    var nonempty = cells.Where(x => x.Field != 0);
                    count = nonempty.Length;
                    for(var j=0; j<ColCount; j++)
                    {
                        ref readonly var field = ref skip(cells,j);

                        if(j==0)
                        {
                            dst.AppendFormat(RowRenderPattern,
                                Rule,
                                field.Table,
                                field.Row,

                                string.Format("{0}:{1}",field.Size.Aligned, field.Size.Packed),
                                field.Field
                                );

                            continue;
                        }

                        if(field.IsEmpty)
                            continue;

                        dst.Append(" | ");
                        dst.AppendFormat(GridCol.RenderPattern,
                            string.Format("{0}:{1}",field.Size.Aligned, field.Size.Packed),
                            field.Field
                            );
                    }
                    dst.AppendLine();
                }
            }

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