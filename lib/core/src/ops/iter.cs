// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct core
    {
        /// <summary>
        /// Applies an action to the sequence of integers min,min+1,...,max - 1
        /// </summary>
        /// <param name="min">The inclusive lower bound of the sequence</param>
        /// <param name="max">The non-inclusive upper bound of the sequence
        /// over intergers over which iteration will occur</param>
        /// <param name="f">The action to be applied to each  value</param>
        [MethodImpl(Inline), Op]
        public static void iter<T>(Pair<T> src, Action<T> f)
            where T : unmanaged
        {
            var min = bw64(src.Left);
            var max = bw64(src.Right);
            for(var i=min; i<max; i++)
                f(@as<T>(i));
        }

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