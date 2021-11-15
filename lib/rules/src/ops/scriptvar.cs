//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        /// <summary>
        /// Creates a non-valued <see cref='ScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        [MethodImpl(Inline), Op]
        public static ScriptVar scriptvar(VarSymbol symbol)
            => new ScriptVar(symbol);

        /// <summary>
        /// Creates a valued <see cref='ScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        /// <param name="value">The variable value</param>
        [MethodImpl(Inline), Op]
        public static ScriptVar scriptvar(VarSymbol symbol, string value)
            => new ScriptVar(symbol, value);
    }
}