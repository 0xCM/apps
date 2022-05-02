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
        public struct GridCol
        {
            public const string RenderPattern = "{0,-5} | {1,-24}";

            public ColType Type;

            public DataSize Size;

            public FieldKind Field;

            public byte Col;

            [MethodImpl(Inline)]
            public GridCol(byte col, DataSize size, FieldKind field)
            {
                Type = field;
                Size = size;
                Col = col;
                Field = field;
            }
        }
    }
}