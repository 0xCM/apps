//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct sys
    {
        [MethodImpl(Options), Op]
        public static Array EnumValues(Type src)
            => Enum.GetValues(src);

        [MethodImpl(Options)]
        public static T[] EnumValues<T>()
            where T : unmanaged, Enum
                => Enum.GetValues<T>();
    }
}