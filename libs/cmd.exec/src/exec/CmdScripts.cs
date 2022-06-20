//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class CmdScripts
    {
        const NumericKind Closure = UnsignedInts;



        [MethodImpl(Inline), Op]
        public static CmdVar var(string name, string value)
            => new CmdVar(name, value);

        public static CmdVar<K> var<K>(string name, K kind, string value)
            where K : unmanaged
                => new CmdVar<K>(name,kind,value);

        public static CmdVar<K,T> var<K,T>(string name, K kind, T value)
            where K : unmanaged
                => new CmdVar<K,T>(name, kind, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(uint index, T value)
            => (index,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(uint index, string name, T value)
            => new CmdArg<T>(index, name, value);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(string name, string value)
            => new CmdArg(name,value);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(string name)
            => new CmdArg(name);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(uint index, string name, string value)
            => new CmdArg(index, name, value);

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