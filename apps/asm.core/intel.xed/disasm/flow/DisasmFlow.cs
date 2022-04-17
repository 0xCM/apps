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
        public ref struct DisasmFlow
        {
            public static void run(IAppService svc, WsContext context)
            {
                var files = context.Files(FileKind.XedRawDisasm);
                iteri(files.Storage, (i,file) => exec(i,file), true);
                void exec(int i, in FileRef src)
                    => run(svc, context, src.DocId, src);
            }

            public static void run(IAppService svc, WsContext context, Hex32 docid, in FileRef src)
                => init(svc,context).Run(docid,src);

            static DisasmFlow init(IAppService svc, WsContext context)
                => new DisasmFlow(context, DisasmTarget.create(svc,context));

            readonly WsContext Context;

            readonly IDisasmTarget Target;

            public DisasmFlow(WsContext context, IDisasmTarget dst)
            {
                Context = context;
                Target = dst;
            }

            public void Dispose()
            {

            }

            public void Run(Hex32 docid, FileRef src)
            {
                var token = Target.Starting(src);
                if(token.IsNonEmpty)
                {
                    var doc = XedDisasm.details(Context,src);
                    var lookup = doc.Blocks.Select(x => (x.DetailRow.IP, x)).ToDictionary();
                    var keys = lookup.Keys.Array().Sort();
                    var blocks = alloc<DetailBlock>(keys.Length);
                    for(var i=0u; i<keys.Length; i++)
                    {
                        ref readonly var ip = ref skip(keys,i);
                        var srcBlock = lookup[ip];
                        ref var detail = ref srcBlock.DetailRow;
                        detail.Seq = i;
                        seek(blocks,i) = srcBlock.WithRow(detail);
                    }

                    for(var i=0u; i<blocks.Length; i++)
                        Step(i,skip(blocks,i));

                    Target.Finished(token);
                }
            }

            void Step(uint seq, in DetailBlock src)
            {
                Target.Computed(seq, src);

                ref readonly var detail = ref src.DetailRow;

                ref readonly var block = ref src.SummaryLines;
                ref readonly var lines = ref block.Lines;
                ref readonly var summary = ref block.Summary;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;

                var xdis = AsmInfo.Empty;
                DisasmParse.parse(lines, out xdis).Require();
                Target.Computed(seq, xdis);

                var props = DisasmProps.Empty;
                DisasmParse.parse(lines, out props);
                Target.Computed(seq, props);

                var fields = XedFields.fields();
                XedDisasm.fields(props, fields, false);
                Target.Computed(seq, fields);

                var kinds = fields.MemberKinds();
                Target.Computed(seq, kinds);

                var state = RuleState.Empty;
                XedState.Edit.fields(fields, kinds, ref state);
                Target.Computed(seq, state);

                var encoding = XedState.Code.encoding(state, asmhex);
                Target.Computed(seq, encoding);
            }
        }
    }
}