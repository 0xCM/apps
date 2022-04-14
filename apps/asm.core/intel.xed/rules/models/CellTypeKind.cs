//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct CellTypeKind : IComparable<CellTypeKind>
        {
            readonly byte Data;

            [MethodImpl(Inline)]
            public CellTypeKind(CellClass @class, RuleOperator op)
            {
                Data = BitNumbers.join((uint4)(byte)@class, (uint4)(byte)op);
            }

            public CellClass Class
            {
                [MethodImpl(Inline)]
                get => (CellClass)((byte)(Data & 0xF));
            }

            public RuleOperator Operator
            {
                [MethodImpl(Inline)]
                get => (RuleOperator)((byte)(Data >> 4 ));
            }

            public int CompareTo(CellTypeKind src)
            {
                var result = Class.CompareTo(src.Class);
                if(result == 0)
                    result = Operator.CompareTo(src.Operator);
                return result;
            }

            public string Format()
                => CellRender.format(this);

           public override string ToString()
                => Format();
        }
    }
}