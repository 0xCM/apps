//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ArrayUtil
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static T single<T>(T[] src)
        {
            var count = src.Length;
            if(count != 1)
                throw new Exception($"There are {src.Length} elements where there should be exactly 1");
            else
                return src[0];
        }
    }
}