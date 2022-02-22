//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial struct Msg
    {
        public static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        public static MsgPattern<ProjectId> LoadingSources
            => "Loading {0} sources";
    }
}