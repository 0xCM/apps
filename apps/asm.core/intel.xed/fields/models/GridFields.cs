//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public readonly struct GridFields
        {
            public readonly RuleSig Rule;

            public readonly ushort RowCount;

            public readonly byte ColCount;

            public readonly Index<GridField> Data;

            public readonly ushort FieldCount;

            public readonly FS.FileUri TablePath;

            [MethodImpl(Inline)]
            public GridFields(RuleSig sig, ushort rows, byte cols, Index<GridField> src)
            {
                Rule = sig;
                RowCount = rows;
                ColCount = cols;
                Data = src;
                FieldCount = Require.equal((ushort)(rows*cols), (ushort)src.Count);
                TablePath = XedPaths.Service.CheckedTableDef(sig);
            }

            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public struct Cell
            {
                public const string RenderPattern = "{0,-5} | {1,-24}";

                public DataSize Size;

                public FieldKind Field;

                public byte Col;

                [MethodImpl(Inline)]
                public Cell(byte col, DataSize size, FieldKind field)
                {
                    Size = size;
                    Col = col;
                    Field = field;
                }

                public void Render(ITextEmitter dst)
                    => dst.AppendFormat(RenderPattern, string.Format("{0}:{1}", Size.Aligned, Size.Packed), Field);
            }

            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public struct GridRow
            {
                public const string RenderPattern = "{0,-32} | {1,-6} | {2,-3}";

                public RuleSig Rule;

                public ushort Index;

                public ushort Row;

                public byte ColCount;

                public Index<Cell> Cols;

                public ref Cell this[byte i]
                {
                    [MethodImpl(Inline)]
                    get => ref Cols[i];
                }

                public uint PackedWidth()
                    => Cols.Storage.Where(c => c.Field != 0).Select(x => (uint)x.Size.Packed).Sum();

                public uint AlignedWidth()
                    => Cols.Storage.Where(c => c.Field != 0).Select(x => (uint)x.Size.Aligned.Value).Sum();

                public void Render(ITextEmitter dst)
                {
                     dst.AppendFormat(RenderPattern, Rule, Index, Row);
                     for(var i=z8; i<ColCount; i++)
                     {
                         ref readonly var col = ref this[i];
                         if(col.Field == 0)
                            continue;

                         dst.Append(" | ");

                         this[i].Render(dst);
                     }
                     dst.Append(Eol);
                }
            }

            public Index<GridRow> Rows()
            {
                var src = Data.View;
                var dst = alloc<GridRow>(RowCount);
                var k=0u;
                for(var i=0; i<RowCount; i++)
                {
                    ref var row = ref seek(dst,i);
                    row.ColCount = ColCount;
                    row.Rule = Rule;
                    row.Cols = alloc<Cell>(ColCount);
                    for(var j=0; j<ColCount; j++, k++)
                    {
                        ref readonly var field = ref Data[k];
                        row.Index = field.Table;
                        row.Row = field.Row;
                        row.Cols[j] = new Cell(field.Col, field.Size, field.Field);
                    }
                }
                return dst;
            }

            const string RowRenderPattern = "{0,-32} | {1,-6} | {2,-3} | {3,-5} | {4,-24}";

            public void Render(ITextEmitter dst)
            {
                var k=0;
                var src = Data.View;

                dst.AppendLine(string.Format("{0,-32} {1}", Rule.Format(), TablePath));
                dst.AppendLine(RP.PageBreak260);
                for(var i=0; i<RowCount; i++)
                {
                    var offset = i*ColCount;
                    var fields = slice(src, offset, ColCount);
                    var count = Require.equal(fields.Length, ColCount);
                    var nonempty = fields.Where(x => x.Field != 0);
                    count = nonempty.Length;
                    for(var j=0; j<ColCount; j++)
                    {
                        ref readonly var field = ref skip(fields,j);

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
                        dst.AppendFormat(Cell.RenderPattern,
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