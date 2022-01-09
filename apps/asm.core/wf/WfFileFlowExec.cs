//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfFileFlowExec : WfStepExec<FS.FilePath,FS.FilePath>
    {
        protected WfFileFlowExec(IWfFileFlow flow, FS.FilePath src, FS.FilePath dst)
            : base(flow,src,dst)
        {

        }
    }
}