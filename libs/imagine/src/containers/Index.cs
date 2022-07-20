//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    [ApiHost]
    public readonly struct Index
    {
        const NumericKind Closure = UInt64k;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool any<T>(T[] src)
            => src?.Length != 0;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool any<T>(T[] src, T match)
        {
            for(var i=0; i<src.Length; i++)
                if(Arrays.skip(src, i).Equals(match))
                    return true;
            return false;
        }

        // [Op,Closures(Closure)]
        // public static T[] filter<T>(T[] src, Func<T,bool> predicate)
        //     => from x in src where predicate(x) select x;

        // public static Y[] map<T,Y>(T[] src, Func<T,Y> selector)
        //     => from x in src select selector(x);

        public static Z[] map<T,Y,Z>(T[] src, Func<T,Index<Y>> lift, Func<T,Y,Z> project)
            => Arrays.array(from x in src
                            from y in lift(x).Storage
                            select project(x, y));

        public static Y[] map<T,Y>(T[] src, Func<T,Index<Y>> lift)
            => Arrays.array(from x in src
                            from y in lift(x).Storage
                            select y);

        // public static Index<T> sort<T>(Index<T> src)
        // {
        //     Array.Sort(src.Storage);
        //     return src;
        // }

        // public static Index<T> sort<T>(T[] src)
        // {
        //     Array.Sort(src);
        //     return new Index<T>(src);
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref T last<T>(T[] src)
        //      => ref seek(src, src.Length - 1);

        // [Op, Closures(Closure)]
        // public static Index<T> reverse<T>(T[] src)
        // {
        //     Array.Reverse(src);
        //     return src;
        // }
    }
}