//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TypeTableRow : IRow<TypeTableRow>
        {
            public const ObjectKind ObjKind = ObjectKind.TypeTableRow;

            public const byte ColCount = 6;

            [RenderWidth(8)]
            public readonly uint Key;

            [RenderWidth(8)]
            public readonly ushort Index;

            [RenderWidth(64)]
            public readonly Label Field;

            [RenderWidth(64)]
            public readonly Label Symbol;

            [RenderWidth(16)]
            public readonly ulong Value;

            [RenderWidth(64)]
            public readonly StringRef Meaning;

            [MethodImpl(Inline)]
            public TypeTableRow(uint key, ushort index, Label field, ulong value, Label symbol, StringRef meaning)
            {
                Key = key;
                Index =index;
                Field = field;
                Value = value;
                Symbol = symbol;
                Meaning = meaning;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTableRow src)
                => Index.CompareTo(src.Index);

            uint IEntity.Key
                => Key;

            public static Index<ColDef> Columns(ref ushort seq)
                => cols(new ColDef[ColCount]{
                col(seq++, nameof(Key), RenderWidths),
                col(seq++, nameof(Index), RenderWidths),
                col(seq++, nameof(Field), RenderWidths),
                col(seq++, nameof(Symbol), RenderWidths),
                col(seq++, nameof(Value), RenderWidths),
                col(seq++, nameof(Meaning), RenderWidths),
                });

            static ReadOnlySpan<byte> RenderWidths => new byte[ColCount]{8,8,64,64,16,64};
        }
    }
}