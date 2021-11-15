//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".wsfiles")]
        Outcome WsFiles(CmdArgs args)
        {
            var result = Outcome.Success;
            var root = State.Workspace().Root;
            if(args.Length == 0)
            {
                Files(root.Files(true));
            }
            else
            {
                var filter = arg(args,0).Value;
                Files(root.Files(filter, true));
            }

            return result;
        }
    }
}
