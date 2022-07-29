//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Refs
    {
        /// <summary>
        /// Presents a generic value as a bytespan
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(in T src)
            where T : struct
                => Spans.cover(@as<T,byte>(src), Sized.size<T>());
    }
}