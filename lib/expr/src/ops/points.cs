//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;

    using Rules;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct points
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Defines a bijective correspondence between members of source/target sequences of common length over a common domain
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target sequence</param>
        /// <typeparam name="T">The domain type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BijectivePoints<T> bijection<T>(Index<T> src, Index<T> dst)
        {
            if(src.Length != dst.Length)
                Errors.ThrowWithOrigin(string.Format("{0} != {1}", src.Length, dst.Length));
            return new BijectivePoints<T>(src, dst);
        }

        /// <summary>
        /// Defines a bijective correspondence between members of source/target sequences of common length
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target sequence</param>
        /// <typeparam name="S">The source domain type</typeparam>
        /// <typeparam name="T">The target domain type</typeparam>
        [MethodImpl(Inline)]
        public static BijectivePoints<S,T> bijection<S,T>(Index<S> src, Index<T> dst)
        {
            if(src.Length != dst.Length)
                Errors.ThrowWithOrigin(string.Format("{0} != {1}", src.Length, dst.Length));
            return new BijectivePoints<S,T>(src, dst);
        }

        [MethodImpl(Inline)]
        public static PointMap<A,B> map<A,B>(A[] a, B[] b)
            => new PointMap<A,B>(a,b);

        public static PointMap<A,B> map<A,B>(Paired<A,B>[] src)
        {
            var count = src.Length;
            var a = alloc<A>(count);
            var b = alloc<B>(count);
            for(var i=0; i<count; i++)
            {
                seek(a,i) = skip(src,i).Left;
                seek(b,i) = skip(src,i).Right;
            }
            return new PointMap<A,B>(a,b);
        }


        /// <summary>
        /// Transforms a bijection into a sequence of replacement rules
        /// </summary>
        /// <param name="spec"></param>
        /// <typeparam name="T"></typeparam>
        [Op, Closures(Closure)]
        public static Span<Replace<T>> replace<T>(in BijectivePoints<T> spec)
            where T : IEquatable<T>
        {
            var src = spec.Source;
            var dst = spec.Target;
            var count = src.Length;
            var buffer = alloc<Replace<T>>(count);
            ref var target = ref first(buffer);
            ref readonly var input = ref src.First;
            ref readonly var output = ref dst.First;
            for(var i=0; i<count; i++)
                seek(target,i) = Rules.rules.replace(skip(input,i), skip(output,i));
            return buffer;
        }

        [Op, Closures(Closure)]
        public static Span<Replace<T>> replace<T>(Index<T> src, Index<T> dst)
            where T : IEquatable<T>
                => replace(bijection<T>(src,dst));
    }
}