//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static PinnedIndex<T> Pin<T>(this Index<T> src)
            where T : unmanaged
                => new PinnedIndex<T>(src.Storage);

        public static PinnedArray<T> Pin<T>(this T[] src)
            where T : unmanaged
                => new PinnedArray<T>(src);

        /// <summary>
        /// Applies a function to an input sequence to yield a transformed output sequence
        /// </summary>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The mapping function</param>
        [MethodImpl(Inline)]
        public static Index<T> Map<S,T>(this Index<S> src, Func<S,T> f)
            => src.Select(item => f(item));
    }
}