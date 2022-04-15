//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        public static void check(WsContext context, in FileRef src)
        {
            var fields = XedFields.fields();
            var file = XedDisasm.loadfile(src);
            var summary = XedDisasm.summarize(context, file);
            var doc = CalcDetailDoc(context, file, summary);
            var props = DisasmProps.Empty;
            var xdis = XDis.Empty;
            for(var i=0u; i<doc.Count; i++)
            {
                var state = RuleState.Empty;
                ref readonly var block = ref doc[i];
                DisasmParse.parse(block.Lines.XDis.Content, out xdis).Require();
                DisasmParse.parse(block.Lines, out props);
                XedDisasm.fields(block.Lines, props, fields);
                var kinds = fields.MemberKinds();
                XedState.Edit.fields(fields, kinds, ref state);
                var encoding = XedState.Code.encoding(state, block.Encoded);
            }
        }

        public ref struct DisasmFlow
        {
            public static DisasmFlow init(WsContext context, IDisasmTarget dst)
                => new DisasmFlow(context,dst);

            public static void run(WsContext context, IAppService svc)
            {
                var files = context.Files(FileKind.XedRawDisasm).Sort();
                void exec(int i, FileRef src)
                {
                    var target = DisasmTarget.create(svc);
                    var flow = DisasmFlow.init(context, target);
                    flow.Run(src);
                }

                iteri(files.Storage, (i,file) => exec(i,file), true);
            }

            readonly WsContext Context;

            readonly IDisasmTarget Target;

            public DisasmFlow(WsContext context, IDisasmTarget dst)
            {
                Context = context;
                Target = dst;
                State = RuleState.Empty;
                Fields = XedFields.fields();
                XDis = XDis.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
            }

            RuleState State;

            Fields Fields;

            XDis XDis;

            DisasmProps Props;

            EncodingExtract Encoding;

            IProjectWs Project
            {
                [MethodImpl(Inline)]
                get => Context.Project;
            }

            public void Dispose()
            {

            }

            void Clear()
            {
                State = RuleState.Empty;
                XDis = XDis.Empty;
                Props = DisasmProps.Empty;
                Encoding = EncodingExtract.Empty;
                Fields.Clear();
            }

            ReadOnlySpan<FieldKind> Step(uint seq, in DetailBlock src)
            {
                ref readonly var block = ref src.Block;
                ref readonly var lines = ref block.Lines;
                ref readonly var summary = ref block.Summary;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;

                DisasmParse.parse(lines.XDis.Content, out XDis).Require();
                Target.Computed(seq, XDis);

                DisasmParse.parse(lines, out Props);
                Target.Computed(seq, Props);

                XedDisasm.fields(lines, Props, Fields, false);
                Target.Computed(seq, Fields);

                var kinds = Fields.MemberKinds();
                Target.Computed(seq, kinds);

                XedState.Edit.fields(Fields, kinds, ref State);
                Target.Computed(seq, State);

                Encoding = XedState.Code.encoding(State, asmhex);
                Target.Computed(seq, Encoding);

                return kinds;
            }

            public void Run(in FileRef src)
            {
                var token = Target.Starting(src);
                if(token.IsNonEmpty)
                {
                    var file = XedDisasm.loadfile(src);
                    Target.Computed(file);

                    var summary = XedDisasm.summarize(Context, file);
                    Target.Computed(summary);
                    var doc = CalcDetailDoc(Context, file, summary);
                    var details = doc.View.ToArray().Select(x => x.Detail).Sort();
                    for(var i=0u; i<details.Length; i++)
                        seek(details,i).Seq = i;

                    for(var i=0u; i<file.LineCount; i++)
                    {
                        Clear();
                        ref readonly var block = ref doc[i];
                        Target.Computed(i, block);
                        Step(i, block);
                    }

                    Target.Finished(token);
                }
            }
        }
    }
}