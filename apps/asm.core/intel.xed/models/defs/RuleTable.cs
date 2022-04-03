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

            public Index<RuleStatement> Body;

            [MethodImpl(Inline)]
            public RuleTable(in RuleSig name, RuleStatement[] body)
            {
                Sig = name;
                Body = body;
            }

            [MethodImpl(Inline)]
            public RuleTable WithBody(RuleStatement[] src)
                => new RuleTable(Sig,src);

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
                get => Body.Count != 0 && Sig.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Sig.Hash;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(RuleTable src)
                => Sig.CompareTo(src.Sig);

            public override int GetHashCode()
                => Hash;

            public static RuleTable Empty
            {
                get
                {
                    var dst = default(RuleTable);
                    dst.Sig = RuleSig.Empty;
                    dst.Body = sys.empty<RuleStatement>();
                    return dst;
                }
            }
        }
    }
}