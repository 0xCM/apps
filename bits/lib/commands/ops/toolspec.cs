//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Cmd
    {
        // [MethodImpl(Inline), Op]
        // public static ToolSpec toolspec(ToolId tool, CmdFlagSpec[] flags, CmdOptionSpec[] options, TextBlock syntax)
        //     => new ToolSpec(tool, flags, options, syntax);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ToolSpec toolspec<T>(CmdFlagSpec[] flags, CmdOptionSpec[] options, TextBlock syntax)
        //     where T : unmanaged
        //         => new ToolSpec(typeof(T).Name, flags, options, syntax);
    }
}