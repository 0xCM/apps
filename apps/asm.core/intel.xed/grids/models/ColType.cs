//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1,Size =4)]
        public readonly record struct ColType
        {
            [MethodImpl(Inline)]
            public ColType(KeywordKind refined)
                => this = Bitfields.join((byte)ColKind.Keyword, (ushort)refined);

            [MethodImpl(Inline)]
            public ColType(FieldKind refined)
                => this = Bitfields.join((byte)ColKind.Field, (ushort)refined);

            [MethodImpl(Inline)]
            public ColType(FieldKind field, OperatorKind op)
                => this = Bitfields.join((byte)ColKind.Expression, Bitfields.join((byte)field, (byte)op));

            [MethodImpl(Inline)]
            public ColType(RuleName refined)
                => this = Bitfields.join((byte)ColKind.Rule, (ushort)refined);

            [MethodImpl(Inline)]
            public ColType(OperatorKind refined)
                => this = Bitfields.join((byte)ColKind.Operator, (ushort)refined);

            [MethodImpl(Inline)]
            public ColType(ColKind k)
                => this = (ushort)k;

            [MethodImpl(Inline)]
            public RuleKeyword ToKeyword()
                => (KeywordKind)Upper;

            [MethodImpl(Inline)]
            public FieldKind ToField()
                => (FieldKind)Upper;

            [MethodImpl(Inline)]
            public RuleName ToRule()
                => (RuleName)Upper;

            [MethodImpl(Inline)]
            public RuleOperator ToOperator()
                => (RuleOperator)Upper;

            public ColKind Kind
            {
                [MethodImpl(Inline)]
                get => (ColKind)(byte)this;
            }

            [MethodImpl(Inline)]
            public K Refined<K>()
                where K : unmanaged
                    => generic<K>(Upper);

            uint Upper
            {
                [MethodImpl(Inline)]
                get => (uint)this >> 24;
            }

            [MethodImpl(Inline)]
            public static implicit operator uint(ColType src)
                => @as<ColType,uint>(src);

            [MethodImpl(Inline)]
            public static implicit operator ColType(uint src)
                => @as<uint,ColType>(src);

            [MethodImpl(Inline)]
            public static implicit operator ColType(FieldKind src)
                => new (src);

            [MethodImpl(Inline)]
            public static explicit operator FieldKind(ColType src)
                => src.ToField();

            [MethodImpl(Inline)]
            public static implicit operator ColType(RuleName src)
                => new (src);

            [MethodImpl(Inline)]
            public static explicit operator RuleName(ColType src)
                => src.ToRule();

            [MethodImpl(Inline)]
            public static implicit operator ColType(OperatorKind src)
                => new (src);

            [MethodImpl(Inline)]
            public static explicit operator RuleOperator(ColType src)
                => src.ToOperator();

            [MethodImpl(Inline)]
            public static implicit operator ColType(RuleOperator src)
                => new (src);

            [MethodImpl(Inline)]
            public static implicit operator ColType(KeywordKind src)
                => new (src);

            [MethodImpl(Inline)]
            public static explicit operator RuleKeyword(ColType src)
                => src.ToKeyword();

            [MethodImpl(Inline)]
            public static implicit operator ColType(RuleKeyword src)
                => new (src.KeywordKind);
        }
    }
}