//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct RuleSigKey : IComparable<RuleSigKey>
        {
            readonly ushort Data;

            [MethodImpl(Inline)]
            public RuleSigKey(RuleName name, RuleTableKind kind)
            {
                Data = (ushort)((ushort)name | ((ushort)kind << 11));
            }

            public RuleName TableName
            {
                [MethodImpl(Inline)]
                get => (RuleName)(Data & Pow2.T10m1);
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => (RuleTableKind)(Data >> 11);
            }

            public readonly bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind == 0;
            }

            public readonly bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind != 0;
            }

            public override int GetHashCode()
                => Data;

            [MethodImpl(Inline)]
            public int CompareTo(RuleSigKey src)
            {
                var result = cmp(TableName,src.TableName);
                if(result == 0)
                    result = cmp(TableKind, src.TableKind);
                return result;
            }

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0}.{1}", TableName, TableKind.ToString().ToUpper());

            public override string ToString()
                => Format();
        }
    }
}