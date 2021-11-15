//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum MsgLevel : uint
    {
        None = 0,

        Babble = 1,

        Trace = 2,

        Status = 4,

        Warn = 8,

        Error = 16,
    }
}