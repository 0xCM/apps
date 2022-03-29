//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleSigKey : IEquatable<RuleSigKey>
        {
            [MethodImpl(Inline)]
            public static RuleSigKey from(in RuleSigRow src)
                => new (src.TableKind, src.TableName.Content);

            [MethodImpl(Inline)]
            public static RuleSigKey define(RuleTableKind kind, string name)
                => new (kind,name);

            readonly Hash32 Hash;

            [MethodImpl(Inline)]
            public RuleSigKey(RuleTableKind kind, string name)
            {
                Hash = alg.hash.marvin(name);
                Hash = bit.set(Hash, 31, kind == RuleTableKind.Enc);
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => bit.test(Hash,31) ? RuleTableKind.Enc : RuleTableKind.Dec;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(RuleSigKey src)
                => Hash == src.Hash;

            public override bool Equals(object src)
                => src is RuleSigKey x && Equals(x);
        }
    }
}