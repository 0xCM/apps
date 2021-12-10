//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    partial class LlvmCmd
    {
        const string OpCodeQuery = "llvm/inst/opcodes";

        [CmdOp(OpCodeQuery)]
        Outcome QueryOpCodes(CmdArgs args)
        {
            var instructions = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var opcodes = Distiller.DistillOpCodes(instructions);
            var keys = opcodes.Keys;
            var count = keys.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                if(opcodes.Find(key, out var mapped))
                {
                    var kinst = mapped.Count;
                    for(var j=0; j<kinst; j++)
                    {
                        ref readonly var inst = ref mapped[j];
                        Write(string.Format("{0,-12} | {1}", key, inst.InstName));
                    }
                }
            }

            return true;
        }
    }
}