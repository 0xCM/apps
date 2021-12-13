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
        [MethodImpl(Inline), Op]
        public static CmdLine cmdline(params string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(ToolId tool, params string[] src)
            => new ToolCmdLine(tool, cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(ToolId tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, cmdline(src));
    }
}