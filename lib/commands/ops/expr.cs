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
        public static ScriptExpr expr(ScriptPattern pattern)
            => new ScriptExpr(pattern);

        [MethodImpl(Inline), Op]
        public static ScriptExpr expr(ScriptPattern pattern, CmdVars vars)
            => new ScriptExpr(pattern, vars);

        [MethodImpl(Inline)]
        public static ScriptExpr<K> expr<K>(ScriptPattern pattern, Index<CmdVar<K>> vars)
            where K : unmanaged
               => new ScriptExpr<K>(pattern, vars);

        [MethodImpl(Inline)]
        public static ScriptExpr<K,T> expr<K,T>(K id, T content)
            where K : unmanaged
                => new ScriptExpr<K,T>(id,content);
    }
}