//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XArray
    {
        public static bool AnyTest<T>(this T[] src, Func<T,bool> predicate)
        {
            foreach(var item in src)
            {
                if(predicate(item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Defines an array-specific join operator
        /// </summary>
        /// <param name="src"></param>
        /// <param name="selector"></param>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        public static T[] SelectMany<S,T>(this S[] src, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(src, selector).ToArray();

        /// <summary>
        /// Sequentially condenses a sequence of arrays into a single array
        /// </summary>
        /// <param name="src">The many</param>
        /// <typeparam name="T">The array element type</typeparam>
        public static T[] Join<T>(this T[][] src)
            => Enumerable.SelectMany(src,x => x).ToArray();

        public static T[] Join<S,T>(this S[] src, Func<S,T[]> f)
            where S : IEnumerable<T>
                => Enumerable.SelectMany(src, f).ToArray();

        public static T[] Join<S,T>(this S[][] src, Func<S,T> f)
            => src.Join().Select(f);

        public static T[] SelectMany<S,T>(this S[][] src, Func<S,T> f)
            => src.Join().Select(f);
    }
}