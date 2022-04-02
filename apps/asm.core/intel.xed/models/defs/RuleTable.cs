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
            public RuleSig Name;

            public Index<RuleStatement> Body;

            [MethodImpl(Inline)]
            public RuleTable(in RuleSig name, RuleStatement[] body)
            {
                Name = name;
                Body = body;
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Name.TableKind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Body.Count == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Body.Count != 0 && Name.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Name.Hash;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(RuleTable src)
                => Name.CompareTo(src.Name);

            public override int GetHashCode()
                => Hash;

            public static RuleTable Empty
            {
                get
                {
                    var dst = default(RuleTable);
                    dst.Name = RuleSig.Empty;
                    dst.Body = sys.empty<RuleStatement>();
                    return dst;
                }
            }
        }
    }
}