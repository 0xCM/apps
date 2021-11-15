//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum ToolScriptKind : ushort
    {
        None = 0,

        Cmd = 1,

        Ps = 2,

        Bash = 4,

        Z = 128
    }
}