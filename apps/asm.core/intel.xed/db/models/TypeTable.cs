//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record("xed.db.typetable")]
        public readonly record struct TypeTable : ITable<TypeTable>
        {
            public const byte ColCount = 4;

            public const ObjectKind ObjKind = ObjectKind.TypeTable;

            public readonly uint Seq;

            public readonly asci32 TypeName;

            public readonly byte TypeWidth;

            public readonly ushort RowCount;

            [Ignore]
            public readonly Index<TypeTableField> Fields;

            [MethodImpl(Inline)]
            public TypeTable(uint seq, asci32 name, byte width, TypeTableField[] rows)
            {
                Seq = seq;
                TypeName = name;
                TypeWidth = width;
                RowCount = (ushort)rows.Length;
                Fields = rows;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTable src)
                => TypeName.CompareTo(src.TypeName);

            static string combined()
            {
                var s0 = z16;
                var s1 = z16;
                var left = Columns(ref s0);
                var right = TypeTableField.Columns(ref s1);
                var joined = resequence(left,right);
                var names = joined.Select(x => x.Name.Format());
                var widths = joined.Select(x => x.Width);
                var pattern = joined.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.Width)).Concat(" | ");
                return pattern;
            }

            public static string header()
            {
                var s0 = z16;
                var s1 = z16;
                var left = Columns(ref s0);
                var right = TypeTableField.Columns(ref s1);
                var joined = resequence(left,right);
                var names = joined.Select(x => x.Name.Format());
                var widths = joined.Select(x => x.Width);
                return string.Format(combined(), names.Storage);
            }

            public string Format()
            {
                var pattern = combined();
                var dst = text.emitter();
                var left = Tables.dynarow(Tables.fields(typeof(TypeTable)));
                left.Update(this);
                var right = Tables.dynarow(Tables.fields(typeof(TypeTableField)));

                for(var j=0; j<Fields.Count; j++)
                {
                    right.Update(Fields[j]);

                    var cells =  (left.Cells.Index() + right.Cells.Index()).Storage;
                    dst.AppendLineFormat(pattern, cells);
                }

                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static Index<ColDef> Columns(ref ushort pos)
                =>  cols(new ColDef[ColCount]{
                    col(pos++, ColKind.U32, nameof(Seq), RenderWidths),
                    col(pos++, ColKind.Asci32, nameof(TypeName), RenderWidths),
                    col(pos++, ColKind.U8, nameof(TypeWidth), RenderWidths),
                    col(pos++, ColKind.U16, nameof(RowCount), RenderWidths),
                        });

            static ReadOnlySpan<byte> RenderWidths => new byte[ColCount]{8,32,12,12};
        }
    }
}