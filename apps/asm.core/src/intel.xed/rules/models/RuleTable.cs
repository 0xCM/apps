//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleTable : IComparable<RuleTable>
        {
            public RuleSig Sig;

            public Index<RuleExpr> Body;

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Sig.TableKind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Body.Count == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Body.Count != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(RuleTable src)
                => Sig.CompareTo(src.Sig);

            public static RuleTable Empty
            {
                get
                {
                    var dst = default(RuleTable);
                    dst.Sig = RuleSig.Empty;
                    dst.Body = sys.empty<RuleExpr>();
                    return dst;
                }
            }
        }
    }
}