//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct RuleSig : IComparable<RuleSig>
        {
            const ushort KindMask = 0xF000;

            const ushort NameMask = 0x0FFF;

            const ushort KindOffset = 12;

            readonly ushort Data;

            [MethodImpl(Inline)]
            public RuleSig(RuleName name, RuleTableKind kind)
            {
                Data = (ushort)((ushort)name | ((ushort)kind << KindOffset));
            }

            public RuleName TableName
            {
                [MethodImpl(Inline)]
                get => (RuleName)(Data & NameMask);
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => (RuleTableKind)((Data & KindMask) >> KindOffset);
            }

            public bool IsEncTable
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.ENC;
            }

            public bool IsDecTable
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.DEC;
            }

            public readonly bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public readonly bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind != 0 && TableName != 0;
            }

            public override int GetHashCode()
                => Data;

            [MethodImpl(Inline)]
            public int CompareTo(RuleSig src)
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

            public static RuleSig Empty => default;
        }
    }
}