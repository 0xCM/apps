//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedFields;
    partial class XedRules
    {
        /// <summary>
        /// Value:[28:13] | DataKind:[12:9] | Operator:[8:6] | FieldKind:[5:0]
        /// </summary>
        [StructLayout(LayoutKind.Sequential,Pack=1,Size =4)]
        public readonly record struct RuleField
        {
            [MethodImpl(Inline)]
            public static implicit operator uint(RuleField src)
                => core.@as<uint>(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleField(uint src)
                => core.@as<RuleField>(src);

            public static RuleField Empty => default;
        }

        public readonly record struct RuleFieldBits
        {
            public static RuleFieldBits create()
                => new RuleFieldBits(Bitfields.dataset<Segment>(FieldKindWidth, OperatorWidth, DataKindWidth, ValueWidth));

            [MethodImpl(Inline)]
            public RuleField Define<T>(FieldKind field, RuleOperator op, RuleCellKind kind, T value)
                where T : unmanaged
            {
                var dst = 0u;
                dst |= (uint)field << Dataset.Offset(Segment.Field);
                dst |= (uint)op << Dataset.Offset(Segment.Operator);
                dst |= (uint)kind << Dataset.Offset(Segment.DataKind);
                dst |= (uint)core.@as<T,ushort>(value) << Dataset.Offset(Segment.Value);
                return dst;
            }

            [MethodImpl(Inline)]
            public RuleField Define<T>(FieldKind field, RuleCellKind kind, T value)
                where T : unmanaged
                    => Define(field, OperatorKind.None, kind, value);

            public readonly BitfieldDataset<Segment> Dataset;

            [MethodImpl(Inline)]
            RuleFieldBits(BitfieldDataset<Segment> src)
            {
                Dataset = src;
            }

            const byte FieldKindWidth = 6;

            const byte OperatorWidth = 3;

            const byte DataKindWidth = 4;

            const byte ValueWidth = 16;

            public enum Segment : byte
            {
                Field,

                Operator,

                DataKind,

                Value,
            }

            public string Format()
                => Dataset.Intervals.Format();

            public override string ToString()
                => Format();

            public string Format(RuleField src, FieldRender render)
            {
                const string Pattern0 = "{0}";
                const string Pattern2 = "{0}{1}{2}";
                var field = Field(src);
                var op = Operator(src);
                var kind = DataKind(src);
                var value = render[field](Value(w16, src));
                var pattern = Pattern0;


                return string.Format("{0}{1}{2}");
            }

            [MethodImpl(Inline)]
            public FieldKind Field(RuleField src)
                => Dataset.Extract<FieldKind>(Segment.Field, src);

            [MethodImpl(Inline)]
            public RuleOperator Operator(RuleField src)
                => Dataset.Extract<RuleOperator>(Segment.Field, src);

            [MethodImpl(Inline)]
            public RuleCellKind DataKind(RuleField src)
                => Dataset.Extract<RuleCellKind>(Segment.Field, src);

            [MethodImpl(Inline)]
            public bit Value(W1 w, RuleField src)
                => Dataset.Extract<bit>(Segment.Field, src);

            [MethodImpl(Inline)]
            public byte Value(W8 w, RuleField src)
                => Dataset.Extract<byte>(Segment.Field, src);

            [MethodImpl(Inline)]
            public ushort Value(W16 w, RuleField src)
                => Dataset.Extract<ushort>(Segment.Field, src);

            [MethodImpl(Inline)]
            public T Value<T>(RuleField src)
                where T : unmanaged
                    => Dataset.Extract<T>(Segment.Field, src);
        }
    }
}