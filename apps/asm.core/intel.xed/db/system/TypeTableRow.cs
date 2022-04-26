//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        public readonly record struct TypeTableRow : IRow<TypeTableRow>
        {
            public static Index<ColDef> Columns => new ColDef[]{
                col(0,ColKind.U16, nameof(Index)),
                col(1,ColKind.U8, nameof(Index)),
                col(2,ColKind.Asci32, nameof(Index)),
                col(3,ColKind.Asci32, nameof(Index)),
                col(4,ColKind.U64, nameof(Index)),
                col(5,ColKind.Asci64, nameof(Index)),
            };

            public readonly ushort Index;

            public readonly byte DataWidth;

            public readonly asci32 Name;

            public readonly asci32 Symbol;

            public readonly ulong Value;

            public readonly asci64 Meaning;

            [MethodImpl(Inline)]
            public TypeTableRow(ushort index, byte width, asci32 name, ulong value, asci32 symbol, asci64 meaning)
            {
                Index =index;
                DataWidth = width;
                Name = name;
                Value = value;
                Symbol = symbol;
                Meaning = meaning;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTableRow src)
                => Index.CompareTo(src.Index);
        }
    }
}