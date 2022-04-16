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
            public static ref FieldBuffer load(in DetailBlock src, ref FieldBuffer dst)
            {
                dst.Clear();
                dst.Detail = src.Detail;
                dst.Lines = src.Block.Lines;
                dst.Summary = src.Block.Summary;
                DisasmParse.parse(dst.Lines, out dst.XDis).Require();
                DisasmParse.parse(dst.Lines, out dst.Props);
                XedDisasm.fields(dst.Props, dst.Fields, false);
                dst.FieldSelection = dst.Fields.MemberKinds();
                XedState.Edit.fields(dst.Fields, dst.FieldSelection, ref dst.State);
                dst.Encoding = XedState.Code.encoding(dst.State, src.Block.Summary.Encoded);
                return ref dst;
            }

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
                XDis = AsmInfo.Empty;
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
                XDis = AsmInfo.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
                FieldSelection = default;
                Detail = DetailBlockRow.Empty;
            }

            public readonly Fields Fields;

            public DetailBlockRow Detail;

            public DisasmLineBlock Lines;

            public DisasmSummary Summary;

            public AsmInfo XDis;

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