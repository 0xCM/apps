//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        /// <summary>
        /// Applies a function to an input sequence to yield a transformed output sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] map<S,T>(S[] src, Func<S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                seek(dst,i) = f(skip(src,i));
            return dst;
        }

        /// <summary>
        /// Applies a function to an input sequence to yield a transformed output sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] map<S,T>(IEnumerable<S> src, Func<S,T> f)
        {
            var source = array(src);
            var count = source.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                seek(dst,i) = f(skip(source,i));
            return dst;
        }
    }
}