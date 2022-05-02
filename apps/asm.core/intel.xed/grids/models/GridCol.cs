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
        public record struct GridCol
        {
            public LogicClass Logic;

            public ColType Type;

            public DataSize Size;

            public FieldKind Field;

            public byte Index;

            [MethodImpl(Inline)]
            public GridCol(LogicClass logic, byte index, DataSize size, ColType type, FieldKind field)
            {
                Logic = logic;
                Type = type;
                Size = size;
                Field = field;
                Index = index;
            }

            public string Format()
                => string.Format("{0,-6} | {1,-3} | {2} | {3,-24}", Logic, Index, Size.Format(2,2,true), XedRender.format(Field));

            public override string ToString()
                => Format();
        }
    }
}