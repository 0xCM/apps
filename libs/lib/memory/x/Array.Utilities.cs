//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ArrayUtil
    {
        const NumericKind Closure = UnsignedInts;

        // [Op, Closures(Closure)]
        // public static T[] where<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        // {
        //     var count = Arrays.count(src,f);
        //     Span<T> dst = alloc<T>(count);
        //     var k = 0;
        //     for(var i=0; i<src.Length; i++)
        //     {
        //         ref readonly var item = ref skip(src,i);
        //         if(f(item))
        //             seek(dst,k++) = item;
        //     }
        //     return slice(dst,0,k).ToArray();
        // }

        [Op, Closures(Closure)]
        public static T single<T>(T[] src)
        {
            var count = src.Length;
            if(count != 1)
                throw new Exception($"There are {src.Length} elements where there should be exactly 1");
            else
                return src[0];
        }

        // [MethodImpl(Inline)]
        // public static T[] map<S,T>(S[] src, Func<S,T> f)
        // {
        //     Span<S> source = src;
        //     var count = source.Length;
        //     var buffer = new T[count];
        //     Span<T> target = buffer;
        //     for(var i=0; i<count; i++)
        //         target[i] = f(source[i]);
        //     return buffer;
        // }
    }
}