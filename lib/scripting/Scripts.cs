//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct Scripts
    {
        /// <summary>
        /// Creates a non-valued <see cref='ScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        [MethodImpl(Inline), Op]
        public static ScriptVar var(VarSymbol symbol)
            => new ScriptVar(symbol);

        /// <summary>
        /// Creates a valued <see cref='ScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        /// <param name="value">The variable value</param>
        [MethodImpl(Inline), Op]
        public static ScriptVar var(VarSymbol symbol, string value)
            => new ScriptVar(symbol, value);
    }
}
