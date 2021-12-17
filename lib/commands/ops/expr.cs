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

        [MethodImpl(Inline)]
        public static CmdScriptExpr<K> expr<K>(CmdScriptPattern pattern, Index<CmdVar<K>> vars)
            where K : unmanaged
               => new CmdScriptExpr<K>(pattern, vars);

        [MethodImpl(Inline)]
        public static CmdScriptExpr<K,T> expr<K,T>(K id, T content)
            where K : unmanaged
                => new CmdScriptExpr<K,T>(id,content);
    }
}