//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost("sys.convert")]
    public class SysConvert
    {
        [MethodImpl(Inline), Op]
        public static char @char(sbyte src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op]
        public static char @char(byte src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op]
        public static char @char(short src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op]
        public static char @char(ushort src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op]
        public static char @char(int src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op]
        public static char @char(uint src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op]
        public static char @char(long src)
            => Convert.ToChar(src);


        [MethodImpl(Inline), Op]
        public static char @char(ulong src)
            => Convert.ToChar(src);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static char @char<T>(T src)
            where T : IConvertible
                => Convert.ToChar(src);

    }
}