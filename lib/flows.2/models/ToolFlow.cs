//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolFlow : FileFlow
    {
        public ToolFlow(IFileFlowType flow, CmdScript script, FS.FilePath src, FS.FilePath dst)
            : base(flow,src,dst)
        {
            Script = script;
        }

        public CmdScript Script {get;}

        public ITool Tool
            => (ITool)FlowType.Actor;
    }
}