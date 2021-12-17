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
        public static CmdVar var(string name, string value)
            => new CmdVar(name, value);

        /// <summary>
        /// Creates a non-valued <see cref='CmdScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(VarSymbol symbol)
            => new CmdScriptVar(symbol);

        /// <summary>
        /// Creates a valued <see cref='CmdScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        /// <param name="value">The variable value</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(VarSymbol symbol, string value)
            => new CmdScriptVar(symbol, value);
    }
}