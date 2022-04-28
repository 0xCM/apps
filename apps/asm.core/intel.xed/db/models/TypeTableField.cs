//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record("xed.db.typetable.field")]
        public readonly record struct TypeTableField : IRow<TypeTableField>
        {
            public const ObjectKind ObjKind = ObjectKind.TypeTableField;

            public const byte ColCount = 7;

            public readonly uint Key;

            public readonly ushort Index;

            public readonly DataSize Size;

            public readonly asci32 Name;

            public readonly asci32 Symbol;

            public readonly ulong Value;

            public readonly asci64 Meaning;

            [MethodImpl(Inline)]
            public TypeTableField(uint key, ushort index, DataSize size, asci32 name, ulong value, asci32 symbol, asci64 meaning)
            {
                Key = key;
                Index =index;
                Size = size;
                Name = name;
                Value = value;
                Symbol = symbol;
                Meaning = meaning;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTableField src)
                => Index.CompareTo(src.Index);

            public string Format()
            {
                return string.Format(DbSvc.Render.Pattern(ObjKind),
                    Key,
                    Index,
                    Size,
                    Name,
                    Symbol,
                    Value,
                    Meaning
                    );
            }

            public override string ToString()
                => Format();

            uint IKeyed.Key
                => Key;

            public static Index<ColDef> Columns(ref ushort seq)
                => cols(new ColDef[ColCount]{
                col(seq++, ColKind.U16, nameof(Key), RenderWidths),
                col(seq++, ColKind.U16, nameof(Index), RenderWidths),
                col(seq++, ColKind.U8, nameof(Size), RenderWidths),
                col(seq++, ColKind.Asci32, nameof(Name), RenderWidths),
                col(seq++, ColKind.Asci32, nameof(Symbol), RenderWidths),
                col(seq++, ColKind.U64, nameof(Value), RenderWidths),
                col(seq++, ColKind.Asci64, nameof(Meaning), RenderWidths),
                });

            static ReadOnlySpan<byte> RenderWidths => new byte[ColCount]{8,8,10,32,32,16,64};
        }
    }
}