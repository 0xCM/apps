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
        public static ToolScript toolscript(ToolId tool, ScriptId script, CmdVars vars)
            => new ToolScript(tool,script,vars);

        [MethodImpl(Inline), Op]
        public static ToolScript toolscript(ToolId tool, ScriptId script, Func<CmdVars> builder)
            => new ToolScript(tool,script, builder());
    }
}