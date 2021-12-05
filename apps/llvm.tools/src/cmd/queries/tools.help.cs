//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("tool/help")]
        Outcome Help(CmdArgs args)
        {
            var id = arg(args,0).Value;
            var help = Toolset.ToolHelp(id);
            var result = Outcome.Success;
            if(help.IsNonEmpty)
            {
                Write(help.Content);
            }
            else
            {
                result = (false,string.Format("Help for {0} not found", id));
            }
            return result;
        }
    }
}