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

    using C = AsciCode;

    partial class text
    {
        /// <summary>
        /// Advances two cells unconditionally
        /// </summary>
        /// <param name="src"></param>
        /// <param name="i"></param>
        /// <param name="a0"></param>
        /// <param name="a1"></param>
        [MethodImpl(Inline), Op]
        public static uint advance(ReadOnlySpan<C> src, ref uint i, out C a0, out C a1)
        {
            a0 = skip(src, i++);
            a1 = skip(src, i++);
            return 2;
        }
    }
}