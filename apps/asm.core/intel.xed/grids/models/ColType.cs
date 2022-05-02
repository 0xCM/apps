//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedDataTypes;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1,Size =4)]
        public readonly record struct ColType
        {
            [MethodImpl(Inline)]
            public static ColType field(FieldKind field)
                => new ColType(ColKind.Field, field);

            [MethodImpl(Inline)]
            public static ColType seg(FieldKind field)
                => new ColType(ColKind.FieldSeg, field);

            [MethodImpl(Inline)]
            public static ColType segvar(FieldKind field)
                => new ColType(ColKind.SegVar);

            [MethodImpl(Inline)]
            public static ColType segval(byte width)
                => new ColType(ColKind.SegVal, width);

            [MethodImpl(Inline)]
            public static ColType bitlit()
                => new ColType(ColKind.BitLiteral);

            [MethodImpl(Inline)]
            public static ColType hexlit()
                => new ColType(ColKind.HexLiteral);

            [MethodImpl(Inline)]
            public static ColType rule()
                => new ColType(ColKind.Rule);

            [MethodImpl(Inline)]
            public static ColType expr(FieldKind field, OperatorKind op)
                => new ColType(field, op);

            [MethodImpl(Inline)]
            public static ColType expr(FieldKind left, OperatorKind op, byte width)
                => new ColType(left, op, width);

            [MethodImpl(Inline)]
            public static ColType nonterm(RuleName rule)
                => new ColType(rule);

            /// <summary>
            /// Defines a rule expression type
            /// </summary>
            /// <param name="field">The field</param>
            /// <param name="op">The operator</param>
            /// <param name="rule">The rule</param>
            [MethodImpl(Inline)]
            public static ColType expr(FieldKind field, OperatorKind op, RuleName rule)
                => new ColType(field, op, rule);

            [MethodImpl(Inline)]
            public ColType(KeywordKind src)
                => this = Bitfields.join((byte)ColKind.Keyword, (ushort)src);

            [MethodImpl(Inline)]
            public ColType(FieldKind src)
                => this = Bitfields.join((byte)ColKind.Field, (ushort)src);

            [MethodImpl(Inline)]
            public ColType(ColKind kind, FieldKind field)
                => this = Bitfields.join((byte)kind, (ushort)field);

            [MethodImpl(Inline)]
            public ColType(FieldKind field, OperatorKind op)
                => this = Bitfields.join((byte)ColKind.Expr, Bitfields.join((byte)field, (byte)op));

            [MethodImpl(Inline)]
            public ColType(FieldKind field, OperatorKind op, RuleName rule)
                => this = Bitfields.join((byte)ColKind.RuleExpr, (byte)field, (ushort)num.pack(num.force(op, n3),num.force(rule, n9)));

            [MethodImpl(Inline)]
            public ColType(FieldKind field, OperatorKind op, byte width)
                => this = Bitfields.join((byte)ColKind.RuleExpr, (byte)field, (ushort)num.pack(num.force(op, n3), width));

            [MethodImpl(Inline)]
            public ColType(RuleName src)
                => this = Bitfields.join((byte)ColKind.Rule, (ushort)src);

            [MethodImpl(Inline)]
            public ColType(OperatorKind src)
                => this = Bitfields.join((byte)ColKind.Operator, (ushort)src);

            [MethodImpl(Inline)]
            public ColType(ColKind k)
                => this = (ushort)k;

            [MethodImpl(Inline)]
            public ColType(ColKind k, byte width)
                => this = Bitfields.join((byte)k,width);

            [MethodImpl(Inline)]
            RuleKeyword Keyword()
                => (KeywordKind)Upper;

            [MethodImpl(Inline)]
            public FieldKind Field()
                => (FieldKind)(Upper & uint7.MaxValue);

            [MethodImpl(Inline)]
            public RuleName ToRule()
                => (RuleName)Upper;

            [MethodImpl(Inline)]
            RuleOperator Op()
                => (RuleOperator)Upper;

            [MethodImpl(Inline)]
            Nonterminal NtCall()
                 => (RuleName)Upper;

            public ColKind Kind
            {
                [MethodImpl(Inline)]
                get => (ColKind)(byte)this;
            }

            public bool IsFieldSeg
            {
                [MethodImpl(Inline)]
                get => Kind == ColKind.FieldSeg;
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
                => src.Field();

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
                => src.Op();

            [MethodImpl(Inline)]
            public static implicit operator ColType(RuleOperator src)
                => new (src);

            [MethodImpl(Inline)]
            public static implicit operator ColType(KeywordKind src)
                => new (src);

            [MethodImpl(Inline)]
            public static explicit operator RuleKeyword(ColType src)
                => src.Keyword();

            [MethodImpl(Inline)]
            public static implicit operator ColType(RuleKeyword src)
                => new (src.KeywordKind);

            public static ColType Empty => default;

            // struct Formatter
            // {
            //     static void NtExpr(ColType src)
            //         => Formatter.fx(Formatter.Key.NtExpr) = src => XedRender.format(src.NtCall());

            //     static void NtCall(ColType src)
            //         => Formatter.fx(Formatter.Key.NtCall) = src => XedRender.format(src.NtCall());

            //     static void Operator()
            //         => Formatter.fx(Formatter.Key.Operator) = src => XedRender.format(src.Op());

            //     static void keyword()
            //         => Formatter.fx(Formatter.Key.Keyword) = src => XedRender.format(src.Keyword());

            //     public enum Key
            //     {
            //         NtCall,

            //         NtExpr,

            //         Operator,

            //         Keyword
            //     }

            //     [MethodImpl(Inline)]
            //     public static ref Formatter formatter(byte key)
            //         => ref _Formatters[key];

            //     [MethodImpl(Inline)]
            //     public static ref Formatter formatter(Key key)
            //         => ref _Formatters[(byte)key];

            //     [MethodImpl(Inline)]
            //     public static ref Func<ColType,string>  fx(byte key)
            //         => ref formatter(key).F;

            //     [MethodImpl(Inline)]
            //     public static ref Func<ColType,string>  fx(Key key)
            //         => ref formatter(key).F;

            //     static Index<Formatter> _Formatters = new Formatter[24];

            //     public readonly byte KeyValue;

            //     Func<ColType,string> F;

            //     [MethodImpl(Inline)]
            //     public Formatter(byte key, Func<ColType,string> f)
            //     {
            //         KeyValue = key;
            //         F = f;
            //     }

            //     public string Format(ColType src)
            //         => F(src);
            // }
        }
    }
}