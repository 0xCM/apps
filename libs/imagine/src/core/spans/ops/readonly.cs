//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class Spans
    {
        /// <summary>
        /// Reflects the immutable self
        /// </summary>
        /// <param name="src">The self</param>
        /// <typeparam name="T">The self cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> @readonly<T>(Span<T> src)
            => src;
    }
}