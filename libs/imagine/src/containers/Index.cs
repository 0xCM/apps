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

        public static Z[] map<T,Y,Z>(T[] src, Func<T,Index<Y>> lift, Func<T,Y,Z> project)
            => Arrays.array(from x in src
                            from y in lift(x).Storage
                            select project(x, y));

        public static Y[] map<T,Y>(T[] src, Func<T,Index<Y>> lift)
            => Arrays.array(from x in src
                            from y in lift(x).Storage
                            select y);
    }
}