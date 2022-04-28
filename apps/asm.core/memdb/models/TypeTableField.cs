//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TypeTableField : IRow<TypeTableField>
        {
            public const ObjectKind ObjKind = ObjectKind.TypeTableField;

            public const byte ColCount = 6;

            [RenderWidth(8)]
            public readonly uint FieldKey;

            [RenderWidth(8)]
            public readonly ushort Index;

            [RenderWidth(64)]
            public readonly asci64 Name;

            [RenderWidth(64)]
            public readonly asci64 Symbol;

            [RenderWidth(16)]
            public readonly ulong Value;

            [RenderWidth(64)]
            public readonly asci64 Meaning;

            [MethodImpl(Inline)]
            public TypeTableField(uint key, ushort index, asci64 name, ulong value, asci64 symbol, asci64 meaning)
            {
                FieldKey = key;
                Index =index;
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
                    FieldKey,
                    Index,
                    Name,
                    Symbol,
                    Value,
                    Meaning
                    );
            }

            public override string ToString()
                => Format();

            uint IEntity.Key
                => FieldKey;

            public static Index<ColDef> Columns(ref ushort seq)
                => cols(new ColDef[ColCount]{
                col(seq++, nameof(FieldKey), RenderWidths),
                col(seq++, nameof(Index), RenderWidths),
                col(seq++, nameof(Name), RenderWidths),
                col(seq++, nameof(Symbol), RenderWidths),
                col(seq++, nameof(Value), RenderWidths),
                col(seq++, nameof(Meaning), RenderWidths),
                });

            static ReadOnlySpan<byte> RenderWidths => new byte[ColCount]{8,8,64,64,16,64};
        }
    }
}