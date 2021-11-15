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
        /// <summary>
        /// Creates a <see cref='ToolCmdArgs'/> collection from an array
        /// </summary>
        /// <param name="src">The source array</param>
        [MethodImpl(Inline), Op]
        public static ScriptPattern pattern(string id, string spec)
            => new ScriptPattern(id, spec);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScriptPattern<K> pattern<K>(K id, string content)
            where K : unmanaged
                => new ScriptPattern<K>(id,content);
    }
}