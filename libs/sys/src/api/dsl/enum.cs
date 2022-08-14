//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class @enum
    {
        const MethodImplOptions Options = MethodImplOptions.AggressiveInlining;

        [MethodImpl(Options), Op]
        public static Array values(Type src)
            => Enum.GetValues(src);

        [MethodImpl(Options)]
        public static T[] values<T>()
            where T : unmanaged, Enum
                => Enum.GetValues<T>();

        [MethodImpl(Options), Op]
        public static string[] names(Type src)
            => Enum.GetNames(src);

        [MethodImpl(Options)]
        public static string[] names<T>()
            where T : unmanaged, Enum
                => names(typeof(T));
    }
}