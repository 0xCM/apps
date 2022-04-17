//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        /// <summary>
        /// Characterizes a disassembled operand class
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public record struct InstOpClass : IComparable<InstOpClass>
        {
            public OpKind Kind;

            public ushort DataWidth;

            public ElementType ElementType;

            public byte CellCount;

            public OpWidthCode WidthCode;

            public OpType OpType;

            public OpAction Action;

            public asci16 Selector;

            public int CompareTo(InstOpClass src)
            {
                var result = XedRules.cmp(Kind,src.Kind);
                if(result == 0)
                    result = DataWidth.CompareTo(src.DataWidth);
                if(result == 0)
                    result = CellCount.CompareTo(src.CellCount);
                if(result == 0)
                    result = ElementType.CompareTo(src.ElementType);
                if(result == 0)
                    result = ((byte)WidthCode).CompareTo((byte)src.WidthCode);
                if(result == 0)
                    result = ((byte)OpType).CompareTo((byte)src.OpType);
                if(result == 0)
                    result = ((byte)Action).CompareTo((byte)src.Action);
                if(result == 0)
                    result = Selector.CompareTo(src.Selector);
                return result;
            }

            public static InstOpClass Empty => default;

        }
    }
}