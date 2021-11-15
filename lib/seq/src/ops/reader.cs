//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    using System;
    using System.Runtime.CompilerServices;

    partial struct seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqReader<T> reader<T>(T* pSrc, long count)
            where T : unmanaged
                => new SeqReader<T>(pSrc, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqReader<T> reader<T>(NativeBuffer<T> src)
            where T : unmanaged
                => new SeqReader<T>(gptr(first(src.Edit)), src.Count);

        /// <summary>
        /// Derives a reader(r0,r1) from readers r0 and r1
        /// </summary>
        /// <param name="r0"></param>
        /// <param name="r1"></param>
        /// <typeparam name="A0"></typeparam>
        /// <typeparam name="A1"></typeparam>
        /// <returns></returns>
        [MethodImpl(Inline)]
        public static SeqReader<A0,A1> reader<A0,A1>(SeqReader<A0> r0, SeqReader<A1> r1)
            where A0 : unmanaged
            where A1 : unmanaged
                => new SeqReader<A0,A1>(r0,r1);
    }
}