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

    using Rules;
    using Ops;

    [ApiHost]
    public readonly partial struct PointFunctions
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
        public static Ops.PointMap<A,B> map<A,B>(A[] a, B[] b)
            => new Ops.PointMap<A,B>(a,b);

        public static Ops.PointMap<A,B> map<A,B>(Paired<A,B>[] src)
        {
            var count = src.Length;
            var a = alloc<A>(count);
            var b = alloc<B>(count);
            for(var i=0; i<count; i++)
            {
                seek(a,i) = skip(src,i).Left;
                seek(b,i) = skip(src,i).Right;
            }
            return new Ops.PointMap<A,B>(a,b);
        }

        public static PointMapper<K,T> mapper<K,T>(Symbols<K> symbols, Func<uint,K,T> f)
            where K : unmanaged
            where T : unmanaged
        {
            var count = symbols.Length;
            var buffer = alloc<Paired<K,T>>(count);
            var symview = symbols.View;
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var k = ref skip(symview,i);
                ref var map = ref seek(dst,i);
                kseek(dst, k.Kind).Left = k.Kind;
                kseek(dst, k.Kind).Right = f(i,k);
            }
            return new PointMapper<K,T>(buffer);
        }

        [Op]
        public static Index<byte> serialize<K,T>(PointMapper<K,T> src)
            where K : unmanaged
            where T : unmanaged
        {
            var points = src.Points;
            var count = points.Length;
            var ksize = size<K>()*count;
            var tsize = size<T>()*count;
            var buffer = alloc<byte>(ksize + tsize);
            var lo = recover<K>(slice(span(buffer),0,size<K>()*count));
            var hi = recover<T>(slice(span(buffer), ksize, tsize));
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                seek(lo,i) = point.Left;
                seek(hi,i) = point.Right;
            }

            return buffer;
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
                seek(target,i) = rules.replace(skip(input,i), skip(output,i));
            return buffer;
        }

        [Op, Closures(Closure)]
        public static Span<Replace<T>> replace<T>(Index<T> src, Index<T> dst)
            where T : IEquatable<T>
                => replace(bijection<T>(src,dst));

        [Op]
        public static Fx8 fx(N8 n, MemoryAddress src, MemoryAddress dst)
            => new Fx8(src, dst);

        [Op, Closures(Closure)]
        public static Fx8<byte,T> fx<T>(N8 n, MemoryAddress src, MemoryAddress dst)
            where T : unmanaged
                => new Fx8<byte,T>(src, dst);

        public static Fx8<S,T> fx<S,T>(N8 n, MemoryAddress src, MemoryAddress dst)
            where T : unmanaged
            where S : unmanaged
                => new Fx8<S,T>(src, dst);

        /// <summary>
        /// Defines a function fx8:u8->T
        /// </summary>
        /// <param name="f">The function under specification</param>
        /// <param name="src">The source domain points</param>
        /// <param name="dst">The target domain points</param>
        /// <typeparam name="T">The target domain</typeparam>
        [Op, Closures(Closure)]
        public static ref Fx8<byte,T> fx<T>(N8 n, ref Fx8<byte,T> f, ReadOnlySpan<byte> src, ReadOnlySpan<T> dst)
            where T : unmanaged
        {
            f.SrcMap.Clear();
            var count = min(min(src.Length, dst.Length), PointFunctions.Fx8.Capacity);
            f.Size = (uint)count;
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                ref readonly var y = ref skip(dst,i);
                f.SrcMap[x] = (byte)i;
            }
            return ref f;
        }

        [Op, Closures(Closure)]
        public static ref Fx8<byte,T> fx<T>(N8 n, ReadOnlySpan<byte> src, ReadOnlySpan<T> dst, out Fx8<byte,T> f)
            where T : unmanaged
        {
            f = fx<T>(n, address(first(src)), address(first(dst)));
            return ref fx(n, ref f, src, dst);
        }

        /// <summary>
        /// Defines a function fx8:u8->T
        /// </summary>
        /// <param name="f">The function under specification</param>
        /// <param name="src">The source domain points</param>
        /// <param name="dst">The target domain points</param>
        /// <typeparam name="T">The target domain</typeparam>
        [Op, Closures(Closure)]
        public static ref Fx16<ushort,T> fx<T>(N16 n, ref Fx16<ushort,T> f, ReadOnlySpan<ushort> src, ReadOnlySpan<T> dst)
            where T : unmanaged
        {
            f.SrcMap.Clear();
            var count = min(min(src.Length, dst.Length), PointFunctions.Fx16<ushort,T>.Capacity);
            f.Size = (uint)count;
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                ref readonly var y = ref skip(dst,i);
                f.SrcMap[x] = (ushort)i;
            }
            return ref f;
        }

        [Op, Closures(Closure)]
        public static Fx16<ushort,T> fx<T>(N16 n, MemoryAddress src, MemoryAddress dst)
            where T : unmanaged
                => new Fx16<ushort,T>(src, dst);

        [Op, Closures(Closure)]
        public static ref Fx16<ushort,T> fx<T>(N16 n, ReadOnlySpan<ushort> src, ReadOnlySpan<T> dst, out Fx16<ushort,T> f)
            where T : unmanaged
        {
            f = fx<T>(n, address(first(src)), address(first(dst)));
            return ref fx(n,ref f, src, dst);
        }
    }
}