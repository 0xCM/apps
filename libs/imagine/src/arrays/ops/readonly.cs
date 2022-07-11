//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        /// <summary>
        /// Reflects the content of an array as a readonly span
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> @readonly<T>(T[] src)
            => src;

    }
}