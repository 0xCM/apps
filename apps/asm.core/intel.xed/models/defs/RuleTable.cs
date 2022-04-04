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

            [MethodImpl(Inline)]
            public FieldSet Fields()
                => fields(this);

            [MethodImpl(Inline)]
            public FieldSet Fields(bool premise)
                => fields(premise, this);

            [MethodImpl(Inline)]
            public void Fields(ref FieldSet dst)
                => fields(this, ref dst);

            [MethodImpl(Inline)]
            public void Fields(bool premise, ref FieldSet dst)
                => fields(premise, this, ref dst);

            [MethodImpl(Inline)]
            public Nonterminals Nonterminals()
                => nonterms(this);

            [MethodImpl(Inline)]
            public Nonterminals Nonterminals(bool premise)
                => nonterms(premise, this);

            [MethodImpl(Inline)]
            public void Nonterminals(ref Nonterminals dst)
                => nonterms(this, ref dst);

            [MethodImpl(Inline)]
            public void Nonterminals(bool premise, ref Nonterminals dst)
                => nonterms(premise, this, ref dst);

            public uint EntryCount
            {
                [MethodImpl(Inline)]
                get => Body.Count;
            }

            public ref RuleStatement this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Body[i];
            }

            public ref RuleStatement this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Body[i];
            }

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