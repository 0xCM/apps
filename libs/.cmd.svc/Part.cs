//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.CmdSvc)]

namespace Z0.Parts
{
    public sealed partial class CmdSvc : Part<CmdSvc>
    {

    }
}

namespace Z0
{
    struct Msg
    {
        public static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

    }
}