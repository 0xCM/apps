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

        public static CmdVar<K> var<K>(string name, K kind, string value)
            where K : unmanaged
                => new CmdVar<K>(name,kind,value);

        public static CmdVar<K,T> var<K,T>(string name, K kind, T value)
            where K : unmanaged
                => new CmdVar<K,T>(name, kind, value);

        /// <summary>
        /// Creates a non-valued <see cref='CmdScriptVar'/>
        /// </summary>
        /// <param name="name">The variable symbol</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(VarSymbol name)
            => new CmdScriptVar(name);

        /// <summary>
        /// Creates a valued <see cref='CmdScriptVar'/>
        /// </summary>
        /// <param name="name">The variable symbol</param>
        /// <param name="value">The variable value</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(VarSymbol name, string value)
            => new CmdScriptVar(name, value);
    }
}