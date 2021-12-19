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
        public static CmdScriptExpr expr(CmdScriptPattern pattern)
            => new CmdScriptExpr(pattern);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(CmdScriptPattern pattern, CmdVars vars)
            => new CmdScriptExpr(pattern, vars);
    }
}