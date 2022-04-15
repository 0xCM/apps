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
        public static void check(WsContext context, in FileRef src, IDisasmTarget dst)
        {
            var doc = XedDisasm.doc(context, src);
            var details = doc.View.ToArray().Select(x => x.Detail).Sort();
            for(var i=0u; i<details.Length; i++)
                seek(details,i).Seq = i;

            var token = dst.Starting(src);
            for(var i=0u; i<doc.Count; i++)
            {
                ref readonly var block = ref doc[i];
                dst.Computed(i,block);
                check(i, doc[i], dst);
            }
            dst.Finished(token);
        }

        static void check(uint i, in DetailBlock block, IDisasmTarget dst)
        {
            var fields = XedFields.fields();
            var state = RuleState.Empty;
            DisasmParse.parse(block.Lines, out XDis xdis).Require();
            dst.Computed(i,xdis);
            DisasmParse.parse(block.Lines, out DisasmProps props);
            dst.Computed(i,props);

            XedDisasm.fields(block.Lines, props, fields);
            dst.Computed(i,fields);

            var kinds = fields.MemberKinds();
            XedState.Edit.fields(fields, kinds, ref state);
            dst.Computed(i,state);

            var encoding = XedState.Code.encoding(state, block.Encoded);
            dst.Computed(i,encoding);
        }

        public ref struct DisasmFlow
        {
            public static DisasmFlow init(WsContext context, IDisasmTarget dst)
                => new DisasmFlow(context,dst);

            public static void run(IAppService svc, WsContext context)
            {
                var files = context.Files(FileKind.XedRawDisasm).Sort();
                void exec(int i, FileRef src)
                {
                    var target = DisasmTarget.create(svc, context);
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

                DisasmParse.parse(lines, out XDis).Require();
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
                    var doc = XedDisasm.doc(Context,src);
                    var details = doc.View.ToArray().Select(x => x.Detail).Sort();
                    for(var i=0u; i<details.Length; i++)
                        seek(details,i).Seq = i;

                    for(var i=0u; i<doc.Count; i++)
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