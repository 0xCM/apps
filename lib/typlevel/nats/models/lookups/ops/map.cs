//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct LookupTables
    {
        /// <summary>
        /// Defines an association between a <see cef='LookupKey'/> and the identified cell
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cell"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static KeyMap<T> map<T>(LookupKey key, T cell)
            => new KeyMap<T>(key,cell);
    }
}