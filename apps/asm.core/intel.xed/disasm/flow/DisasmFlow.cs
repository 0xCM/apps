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
        public struct DisasmFlow
        {
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

            public void Run(in FileRef src)
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
                parse(lines, out xdis).Require();
                Target.Computed(seq, xdis);

                var props = DisasmProps.Empty;
                XedDisasm.parse(lines, out props);
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