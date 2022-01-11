//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfFileFlowExec : FlowExec<FS.FilePath,FS.FilePath>
    {
        protected WfFileFlowExec(IFileFLow flow, FS.FilePath src, FS.FilePath dst)
            : base(flow,src,dst)
        {

        }
    }
}