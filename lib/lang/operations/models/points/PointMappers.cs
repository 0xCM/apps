//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System;

    public readonly struct PointMappers
    {
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
    }
}