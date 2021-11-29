//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    using static Root;
    using static minicore;

    [ApiHost]
    public readonly struct Index
    {
        const NumericKind Closure = UInt64k;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool any<T>(Index<T> src)
            => src.Count != 0;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool contains<T>(Index<T> src, T match)
        {
            var count = src.Count;
            ref var source = ref src.First;
            for(var i=0; i<count; i++)
                if(skip(source, i).Equals(match))
                    return true;
            return false;
        }

        [Op, Closures(Closure)]
        public static IEnumerable<T> enumerate<T>(ReadOnlySpan<T> src)
            => src.ToArray();

        [Op, Closures(Closure)]
        public static IEnumerator<T> enumerator<T>(ReadOnlySpan<T> src)
            => enumerate(src).GetEnumerator();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool equals<T>(ReadOnlySpan<T> src, ReadOnlySpan<T> dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            if(count != dst.Length)
                return false;

            if(count == 0)
                return true;

            ref readonly var a = ref first(src);
            ref readonly var b = ref first(dst);
            for(var i=0; i<count; i++)
                if(!skip(a,i).Equals(skip(b,i)))
                    return false;

            return true;
        }

        [MethodImpl(Inline)]
        public static bool equals<T,C>(ReadOnlySpan<T> src, ReadOnlySpan<T> dst, C comparer)
            where C : IEqualityComparer<T>
        {
            var count = src.Length;
            if(count != dst.Length)
                return false;

            if(count == 0)
                return true;

            ref readonly var a = ref first(src);
            ref readonly var b = ref first(dst);
            for(var i=0; i<count; i++)
                if(!comparer.Equals(skip(a,i),skip(b,i)))
                    return false;

            return true;
        }

        [Op,Closures(Closure)]
        public static T[] filter<T>(T[] src, Func<T,bool> predicate)
            => from x in src where predicate(x) select x;

        public static Y[] map<T,Y>(T[] src, Func<T,Y> selector)
            => from x in src select selector(x);

        public static Z[] map<T,Y,Z>(T[] src, Func<T,Index<Y>> lift, Func<T,Y,Z> project)
            => array(from x in src
                            from y in lift(x).Storage
                            select project(x, y));

        public static Y[] map<T,Y>(T[] src, Func<T,Index<Y>> lift)
            => array(from x in src
                            from y in lift(x).Storage
                            select y);

        public static Index<T> sort<T>(Index<T> src)
        {
            Array.Sort(src.Storage);
            return src;
        }

        public static Index<T> sort<T>(T[] src)
        {
            Array.Sort(src);
            return new Index<T>(src);
        }

        /// <summary>
        /// Returns the first element if it exists; otherwise returns the supplied default
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="src">The items to search</param>
        /// <param name="default">The replacement value if the sequence is empty</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T firstOrDefault<T>(Index<T> src, T @default = default)
            => any(src) ? src.First : @default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T last<T>(T[] src)
             => ref seek(src, src.Length - 1);

        [Op, Closures(Closure)]
        public static Index<T> reverse<T>(T[] src)
        {
            Array.Reverse(src);
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool search<T>(T[] src, Func<T,bool> predicate, out T found)
        {
            var view = @readonly(src);
            var count = view.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var candidate = ref skip(view,i);
                if(predicate(candidate))
                {
                    found = candidate;
                    return true;
                }
            }
            found = default;
            return false;
        }
    }
}