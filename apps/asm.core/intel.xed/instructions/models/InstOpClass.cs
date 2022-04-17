//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedRules
    {
        /// <summary>
        /// Characterizes a disassembled operand class
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public record struct InstOpClass : IComparable<InstOpClass>
        {
            public OpKind Kind;

            public ushort DataWidth;

            public OpWidthCode WidthCode;

            public ElementType ElementType;

            public byte CellCount;

            public bit IsRegLit;

            public bit IsLookup;

            public asci16 Selector;

            public int CompareTo(InstOpClass src)
                => XedRules.cmp(this,src);

            public static InstOpClass Empty => default;

        }
    }
}