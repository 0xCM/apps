// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Collections.Generic;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Iterates over the supplied items, invoking a receiver for each
        /// </summary>
        /// <param name="src">The source items</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The item type</typeparam>
        public static void iter<T>(IEnumerable<T> items, Action<T> action, bool pll = false)
        {
            if (pll)
                items.AsParallel().ForAll(item => action(item));
            else
                foreach (var item in items)
                    action(item);
        }

        /// <summary>
        /// Iterates over the supplied items, invoking a receiver for each
        /// </summary>
        /// <param name="src">The source items</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The item type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(T[] src, Action<T> action)
            => iter(@readonly(src),  action);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(ReadOnlySpan<T> src, Action<T> action, bool pll = false)
        {
            if(pll)
            {
                src.ToArray().AsParallel().ForAll(item => action(item));
            }
            else
            {
                var count = src.Length;
                for(var i=0u; i<count; i++)
                    action(skip(src,i));
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(Span<T> src, Action<T> action)
            => iter(src.ReadOnly(), action);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(SortedSpan<T> src, Action<T> action)
            => iter(src.View, action);

        /// <summary>
        /// Iterates over the supplied items, invoking a receiver for each
        /// </summary>
        /// <param name="src">The source items</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The item type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(Index<T> src, Action<T> action)
            => iter(src.View,  action);

        /// <summary>
        /// Iterates a pair of readonly spans in tandem, invoking a caller-supplied action for each cell pair
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="f">The action to invoke</param>
        /// <typeparam name="S">The cell type of the first operand</typeparam>
        /// <typeparam name="T">The cell type of the second operand</typeparam>
        [MethodImpl(Inline)]
        public static void iter<S,T>(ReadOnlySpan<S> x, ReadOnlySpan<T> y, Action<S,T> f)
        {
            var count = min(x.Length, y.Length);
            for(var i=0u; i<count; i++)
                f(skip(x,i),skip(y,i));
        }

        /// <summary>
        /// Iterates a pair of spans in tandem, invoking a caller-supplied action for each cell pair
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="f">The action to invoke</param>
        /// <typeparam name="S">The cell type of the first operand</typeparam>
        /// <typeparam name="T">The cell type of the second operand</typeparam>
        [MethodImpl(Inline)]
        public static void iter<S,T>(Span<S> x, Span<T> y, Action<S,T> f)
        {
            var count = min(x.Length, y.Length);
            for(var i=0u; i<count; i++)
                f(skip(x,i),skip(y,i));
        }
    }
}