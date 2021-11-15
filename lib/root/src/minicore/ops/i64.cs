//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct minicore
    {
        /// <summary>
        /// Presents a <see cref='bool'/> as a <see cref='long'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static unsafe long i64(bool src)
            => *((sbyte*)(&src));

        /// <summary>
        /// Presents a T-references as a <see cref='long'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long i64<T>(in T src)
            => ref @as<T,long>(src);
    }
}