//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;
    using static Arrays;

    partial class Algs
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

        public static void iter<S,T>(ReadOnlySpan<S> src, Func<S,T> f, ConcurrentBag<T> dst, bool pll = true)
            => iter(src, item => dst.Add(f(item)), pll);

        public static void iter<S,T>(ReadOnlySpan<S> src, Func<S,T> f, List<T> dst, bool pll = false)
            => iter(src, item => dst.Add(f(item)), pll);

        /// <summary>
        /// Iterates over the supplied items, invoking a receiver for each
        /// </summary>
        /// <param name="src">The source items</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(Closure)]
        public static void iter<T>(T[] src, Action<T> action)
            => iter(@readonly(src),  action);

        [Op, Closures(Closure)]
        public static void iter<T>(ReadOnlySpan<T> src, Action<T> action, bool pll = false)
        {
            if(pll)
                src.ToArray().AsParallel().ForAll(item => action(item));
            else
            {
                for(var i=0u; i<src.Length; i++)
                    action(skip(src,i));
            }
        }

        [Op, Closures(Closure)]
        public static void iter<T>(Span<T> src, Action<T> action)
            => iter(src.ReadOnly(), action);
    }
}