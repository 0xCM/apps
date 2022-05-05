//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedOperands;
    using static XedRules.OperandStates;

    partial class XedDisasm
    {
        public static OperandStates states(in DataFile src, bool pll)
        {
            if(pll)
            {
                var dst = bag<Entry>();
                iter(src.Blocks, b => dst.Add(state(b)));
                return new OperandStates(dst.Array().Sort());
            }
            else
            {
                var pcount = 0u;
                var vcount = 0u;
                ref readonly var blocks = ref src.Blocks;
                var buffer = alloc<Entry>(blocks.Count);
                for(var i=0u; i<blocks.Count; i++ )
                {
                    ref var entry = ref seek(buffer,i);
                    ref readonly var block = ref blocks[i];
                    entry.Ops = XedDisasm.ops(block);
                    entry.Asm = asminfo(block);
                    var props = XedDisasm.props(block);
                    pcount += (uint)props.Count;
                    var values = FieldParser.parse(props, out seek(buffer,i).State);
                    vcount += values.Count;
                }

                Require.equal(pcount,vcount);
                return new OperandStates(buffer);
            }
        }

        public static Entry state(in DisasmBlock block)
        {
            var dst = Entry.Empty;
            dst.Ops = XedDisasm.ops(block);
            dst.Asm = asminfo(block);
            FieldParser.parse(XedDisasm.props(block), out dst.State);
            return dst;
        }
    }
}