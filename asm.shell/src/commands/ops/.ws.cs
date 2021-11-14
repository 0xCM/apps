//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".ws")]
        Outcome SetWorkspace(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Length == 0)
            {
                Write(State.Workspace().Name);
            }
            else
            {
                var name = arg(args,0).Value;
                result = State.Workspace(name);
                if(result)
                {
                    var ws = State.Workspace();
                    Write(string.Format("{0} workspace selected", ws.Name));
                }
            }
            return result;
        }
    }
}