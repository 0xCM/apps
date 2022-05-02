//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct GridCol
        {
            public readonly CellKey Key;

            public readonly ColType Type;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public GridCol(CellKey key, ColType type, DataSize size)
            {
                Key = key;
                Type = type;
                Size = size;
            }

            public LogicClass Logic
            {
                [MethodImpl(Inline)]
                get => Key.Logic;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Key.Field;
            }

            public byte Index
            {
                [MethodImpl(Inline)]
                get => Key.Col;
            }

            public ushort Row
            {
                [MethodImpl(Inline)]
                get => Key.Row;
            }

            public string Format()
                => string.Format("{2,-24} | {0,-2} | {1,-3} | {3}", XedRender.format(Field), Index, Logic, Size.Format(2,2,true));

            public override string ToString()
                => Format();
        }
    }
}