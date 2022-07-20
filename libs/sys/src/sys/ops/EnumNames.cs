//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct sys
    {
        [MethodImpl(Options), Op]
        public static string[] EnumNames(Type src)
            => Enum.GetNames(src);

        [MethodImpl(Options)]
        public static string[] EnumNames<T>()
            where T : unmanaged, Enum
                => EnumNames(typeof(T));
    }
}