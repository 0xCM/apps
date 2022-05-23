//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Arrays
    {
        [Op, Closures(Closure)]
        public static T single<T>(T[] src)
        {
            var count = src.Length;
            if(count != 1)
                Errors.Throw($"There are {src.Length} elements where there should be exactly 1");
            return core.first(src);
        }
    }
}