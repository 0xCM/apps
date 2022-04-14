//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TableColumn
        {
            public readonly byte Index;

            public readonly CellType Type;

            [MethodImpl(Inline)]
            public TableColumn(byte index, CellType type)
            {
                Index = index;
                Type = type;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Type.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Type.IsEmpty;
            }

            public string Format()
                => Type.Format();

            public override string ToString()
                => Format();

            public static TableColumn Empty => default;
        }
    }
}