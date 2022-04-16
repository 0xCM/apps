//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public ref struct FieldBuffer
        {
            public FieldBuffer Load(in DetailBlock src)
            {
                load(src, ref this);
                return this;
            }

            public static FieldBuffer init()
                => new FieldBuffer(XedFields.fields());

            [MethodImpl(Inline)]
            public static FieldBuffer init(Fields fields)
                => new FieldBuffer(fields);

            [MethodImpl(Inline)]
            FieldBuffer(Fields fields)
            {
                Fields = fields;
                State = RuleState.Empty;
                Summary = DisasmSummary.Empty;
                Lines = DisasmLineBlock.Empty;
                AsmInfo = AsmInfo.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
                FieldSelection = default;
                Detail = DetailBlockRow.Empty;
            }

            public void Clear()
            {
                Fields.Clear();
                State = RuleState.Empty;
                Summary = DisasmSummary.Empty;
                Lines = DisasmLineBlock.Empty;
                AsmInfo = AsmInfo.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
                FieldSelection = default;
                Detail = DetailBlockRow.Empty;
            }

            public readonly Fields Fields;

            public DetailBlockRow Detail;

            public DisasmLineBlock Lines;

            public DisasmSummary Summary;

            public AsmInfo AsmInfo;

            public DisasmProps Props;

            public RuleState State;

            public EncodingExtract Encoding;

            public ReadOnlySpan<FieldKind> FieldSelection;

            public InstForm Form
            {
                [MethodImpl(Inline)]
                get => Detail.InstForm;
            }

            public DisasmOpDetails Ops
            {
                [MethodImpl(Inline)]
                get => Detail.Ops;
            }
        }
    }
}