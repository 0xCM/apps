//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum ProcessContextFlag : byte
    {
        None,

        Summary = 1,

        Detail = 2,

        Dump = 4,

        Hashes = 8,

        All = Summary | Detail | Dump | Hashes
    }
}