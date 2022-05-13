//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedFields;
    using static XedRules;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static RuleCellKind CellKind(this RuleFieldBits src, RuleField field)
            => src.DataKind(field);

        [MethodImpl(Inline)]
        public static FieldKind FieldKind(this RuleFieldBits src, RuleField field)
            => src.Field(field);

        [MethodImpl(Inline)]
        public static RuleOperator Operator(this RuleFieldBits src, RuleField field)
            => src.Operator(field);

        [MethodImpl(Inline)]
        public static ushort CellValue(this RuleFieldBits src, RuleField field)
            => src.Value(w16,field);
    }

    partial class XedRules
    {
        public readonly record struct RuleFieldBits
        {
            public static RuleFieldBits create()
                => new RuleFieldBits(BfDatasets.create<Segment>(FieldKindWidth, OperatorWidth, DataKindWidth, ValueWidth));

            [MethodImpl(Inline)]
            public RuleField Define<T>(FieldKind field, RuleOperator op, RuleCellKind kind, T value)
                where T : unmanaged
            {
                var dst = 0u;
                dst |= (uint)field << (int)Dataset.Offset(Segment.Field);
                dst |= (uint)op << (int)Dataset.Offset(Segment.Operator);
                dst |= (uint)kind << (int)Dataset.Offset(Segment.DataKind);
                dst |= (uint)core.@as<T,ushort>(value) << (int)Dataset.Offset(Segment.Value);
                return (RuleField)dst;
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
                var dst = EmptyString;
                var field = Field(src);
                var op = Operator(src);
                var kind = DataKind(src);
                var value = render[field](Value(w16, src));
                dst = XedRender.format(field) + op.Format() + value;
                return dst;
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