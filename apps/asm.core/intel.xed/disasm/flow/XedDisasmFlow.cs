//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedDisasm;

    public ref struct XedDisasmFlow
    {
        public static XedDisasmFlow init(WsContext context, IXedDisasmTarget dst)
            => new XedDisasmFlow(context,dst);

        readonly WsContext Context;

        readonly Fields Fields;

        readonly Span<FieldKind> Members;

        readonly IXedDisasmTarget Target;

        XedDisasmFlow(WsContext context, IXedDisasmTarget dst)
        {
            Context = context;
            Fields = new Fields(alloc<Field>(Fields.MaxCount));
            Members = alloc<FieldKind>(Fields.MaxCount);
            File = DisasmFile.Empty;
            Props = DisasmProps.Empty;
            XDis = XDis.Empty;
            Source = FileRef.Empty;
            Doc = DisasmSummaryDoc.Empty;
            MemberCount = 0;
            Encoding = EncodingExtract.Empty;
            DetailRow = DetailBlockRow.Empty;
            Block = DetailBlock.Empty;
            Target = dst;
            State = RuleState.Empty;
            AsmHex = AsmHexCode.Empty;
       }

        FileRef Source;

        DisasmFile File;

        DisasmProps Props;

        XDis XDis;

        DisasmSummaryDoc Doc;

        uint MemberCount;

        EncodingExtract Encoding;

        DetailBlockRow DetailRow;

        DetailBlock Block;

        RuleState State;

        AsmHexCode AsmHex;

        void Clear()
        {
            Source = FileRef.Empty;
            File = DisasmFile.Empty;
            Props = DisasmProps.Empty;
            XDis = XDis.Empty;
            Doc = DisasmSummaryDoc.Empty;
            MemberCount = 0;
            Encoding = EncodingExtract.Empty;
            DetailRow = DetailBlockRow.Empty;
            Block = DetailBlock.Empty;
            State = RuleState.Empty;
            AsmHex = AsmHexCode.Empty;
            Fields.Clear();
        }

        public void Run(in FileRef src)
        {
            Clear();
            Source = src;
            Run();
        }

        void Complete()
        {

        }

        void Run()
        {
            Target.Running(Source);
            Steps();
        }

        void Completed(uint seq)
        {

        }

        void Steps()
        {
            Step(Source);
            Step(File);

            for(var i=0u; i<Doc.Blocks.Count; i++)
            {
                Step(Doc.Blocks[i]);
                Step(Block);
                Step(ref State);
                Step(State, AsmHex);
                Completed(i);
            }
        }

        void Step(in DisasmSummaryLines src)
        {
            DetailRow = CalcDetailRow(src);
            Block = new DetailBlock(DetailRow, src);
            Target.Computed(Block);
        }

        void Step(in FileRef src)
        {
            File = XedDisasm.loadfile(src);
            Target.Computed(File);
        }

        void Step(in RuleState state, in AsmHexCode hex)
        {
            Encoding = XedState.Code.encoding(state, hex);
            Target.Computed(Encoding);
        }

        void Step(in DisasmFile src)
        {
            Doc = XedDisasm.summarize(Context,src);
            Target.Computed(Doc);
        }

        void Step(in DetailBlock src)
        {
            AsmHex = src.Encoded;

            var state = RuleState.Empty;
            DisasmParse.parse(src.Lines.XDis.Content, out XDis).Require();
            Target.Computed(XDis);

            DisasmParse.parse(src.Lines, out Props);
            Target.Computed(Props);

            XedDisasm.fields(src.Lines, Props, Fields, false);
            Target.Computed(Fields);
        }

        void Step(ref RuleState dst)
        {
            MemberCount = Fields.Members(Members);
            var kinds = slice(Members,0,MemberCount);
            Target.Computed(kinds);

            XedState.Edit.fields(Fields, kinds, ref dst);
            Target.Computed(dst);
        }
    }
}