//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("xed/disasm/blocks")]
        protected Outcome EmitXedDisasmBlocks(CmdArgs args)
        {

            var src = Project().OutFiles(FS.ext("xed.txt"));
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                var blocks = XedDisasm.ParseBlocks(path);
                var result = XedDisasm.ParseInstructions(blocks, out var instructions);
                if(result.Fail)
                    return result;

                var kI = instructions.Count;
                for(var j=0; j <kI; j++)
                {
                    ref readonly var inst = ref instructions[j];
                    Write(string.Format("{0,-16} | {1,-64} | {2}", inst.Class, inst.Form, inst.Props.Delimit()));
                }
            }

            return true;
        }
    }
}