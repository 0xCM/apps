//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    //[ApiHost]
    public readonly struct ArrayUtil
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static uint count<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            {
                if(f(skip(src,i)))
                    k++;
            }
            return k;
        }

        /// <summary>
        /// Allocates and populates a new array by filtering the source array with a specified predicate
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The predicate</param>
        /// <typeparam name="T">The array element type</typeparam>
        [Op, Closures(Closure)]
        public static T[] where<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var count = ArrayUtil.count(src,f);
            var dst = alloc<T>(count);
            var k = 0;
            for(var i=0; i<src.Length; i++)
            {
                if(f(skip(src,i)))
                    seek(dst,k++) = skip(src,i);
            }
            return dst;
            //return dst.Slice(0, (int)j).ToArray();
        }

        [Op, Closures(Closure)]
        public static T single<T>(T[] src)
        {
            var count = src.Length;
            if(count != 1)
                throw new Exception($"There are {src.Length} elements where there should be exactly 1");
            else
                return src[0];
        }

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
            Span<S> source = src;
            var count = source.Length;
            var buffer = new T[count];
            Span<T> target = buffer;
            for(var i=0; i<count; i++)
                target[i] = f(source[i]);
            return buffer;
        }
    }
}