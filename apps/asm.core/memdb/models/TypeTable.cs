//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TypeTable : ITable<TypeTable>
        {
            public const byte ColCount = 5;

            public const ObjectKind ObjKind = ObjectKind.TypeTable;

            [RenderWidth(8)]
            public readonly uint TypeKey;

            [RenderWidth(32)]
            public readonly asci64 TypeName;

            [RenderWidth(12)]
            public readonly byte PackedWidth;

            [RenderWidth(12)]
            public readonly uint NativeWidth;

            [RenderWidth(12)]
            public readonly ushort RowCount;

            [Ignore]
            public readonly Index<TypeTableRow> Rows;

            [MethodImpl(Inline)]
            public TypeTable(uint key, asci64 name, DataSize size, TypeTableRow[] rows)
            {
                TypeKey = key;
                TypeName = name;
                NativeWidth = size.NativeWidth;
                PackedWidth = (byte)size.PackedWidth;
                RowCount = (ushort)rows.Length;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTable src)
                => TypeName.CompareTo(src.TypeName);

            static string combined()
            {
                var s0 = z16;
                var s1 = z16;
                var left = Columns(ref s0);
                var right = TypeTableRow.Columns(ref s1);
                var joined = resequence(left,right);
                var names = joined.Select(x => x.ColName.Format());
                var widths = joined.Select(x => x.RenderWidth);
                var pattern = joined.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.RenderWidth)).Concat(" | ");
                return pattern;
            }

            public static string header()
            {
                var s0 = z16;
                var s1 = z16;
                var left = Columns(ref s0);
                var right = TypeTableRow.Columns(ref s1);
                var joined = resequence(left,right);
                var names = joined.Select(x => x.ColName.Format());
                var widths = joined.Select(x => x.RenderWidth);
                return string.Format(combined(), names.Storage);
            }

            public string Format()
            {
                var pattern = combined();
                var dst = text.emitter();
                var left = Tables.dynarow(Tables.fields(typeof(TypeTable)));
                left.Update(this);
                var right = Tables.dynarow(Tables.fields(typeof(TypeTableRow)));

                for(var j=0; j<Rows.Count; j++)
                {
                    right.Update(Rows[j]);

                    var cells =  (left.Cells.Index() + right.Cells.Index()).Storage;
                    dst.AppendLineFormat(pattern, cells);
                }

                return dst.Emit();
            }

            public override string ToString()
                => Format();

            uint IEntity.Key
                => TypeKey;

            public static Index<ColDef> Columns(ref ushort pos)
                =>  cols(new ColDef[ColCount]{
                    col(pos++, nameof(TypeKey), RenderWidths),
                    col(pos++, nameof(TypeName), RenderWidths),
                    col(pos++, nameof(PackedWidth), RenderWidths),
                    col(pos++, nameof(NativeWidth), RenderWidths),
                    col(pos++, nameof(RowCount), RenderWidths),
                        });

            static ReadOnlySpan<byte> RenderWidths => new byte[ColCount]{8,32,12,12,12};
        }
    }
}