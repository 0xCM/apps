//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedRules.OperandStates;

    partial class XedDisasm
    {
        public static OperandStates states(in DataFile src, bool pll = true)
        {
            if(pll)
            {
                var dst = bag<Entry>();
                iter(src.Blocks, b => dst.Add(state(b)));
                return new OperandStates(dst.Array().Sort());
            }
            else
            {
                ref readonly var blocks = ref src.Blocks;
                var buffer = alloc<Entry>(blocks.Count);
                for(var i=0u; i<blocks.Count; i++ )
                    seek(buffer,i) = state(blocks[i]);
                return new OperandStates(buffer);
            }
        }

        public static Entry state(in DisasmBlock block)
        {
            var dst = Entry.Empty;
            dst.Asm = block.ParseAsm();
            dst.Ops = block.ParseOps();
            dst.Fields = block.ParseProps().ParseFields(out dst.State);
            return dst;
        }
    }
}