//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var src = Xed.Rules.LoadPatternInfo();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var opcode = ref src[i];
                Write(string.Format("{0,-24} | {1,-24} | {2}", opcode.Class, opcode.OpCode, opcode.Body));
            }

            return true;
        }
    }
}