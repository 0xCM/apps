//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfToolExec : WfFileFlowExec
    {
        public WfToolExec(IWfFileFlow flow, CmdScript script, FS.FilePath src, FS.FilePath dst)
            : base(flow,src,dst)
        {
            Script = script;
        }

        public CmdScript Script {get;}

        public IWfToolActor Tool
            => (IWfToolActor)Flow.Actor;
    }
}