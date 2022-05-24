//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedOperands;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        readonly struct Flow : IFlow
        {
            readonly WsContext Context;

            [MethodImpl(Inline)]
            public Flow(WsContext context)
            {
                Context = context;
            }

            public void Run(in FileRef src, ITarget dst)
            {
                var token = dst.Starting(Context,src);
                if(token.IsNonEmpty)
                {
                    var doc = detail(Context, src);
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
                        Step(i, skip(blocks,i), dst);

                    dst.Finished(token);
                }
            }

            void Step(uint seq, in DetailBlock src, ITarget dst)
            {
                ref readonly var detail = ref src.DetailRow;
                ref readonly var block = ref src.SummaryLines;
                ref readonly var lines = ref block.Block;
                ref readonly var summary = ref block.Row;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;
                ref readonly var ops = ref detail.Ops;

                dst.Computing(seq, src.Instruction);

                var xdis = asminfo(lines);
                dst.Computed(seq, xdis);

                var props = InstFieldValues.Empty;
                XedDisasm.parse(lines, out props);
                dst.Computed(seq, props);

                var fields = Fields.allocate();
                FieldParser.parse(props, fields, false);
                dst.Computed(seq, fields);

                var kinds = fields.MemberKinds();
                dst.Computed(seq, kinds);

                dst.Computed(seq, ops);

                var state = OperandState.Empty;
                XedOperands.update(fields, kinds, ref state);
                dst.Computed(seq, state);

                var encoding = XedState.Code.encoding(state, asmhex);
                dst.Computed(seq, encoding);

                dst.Computed(seq, src.Instruction);
            }
        }
    }
}