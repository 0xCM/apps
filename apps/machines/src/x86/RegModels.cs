//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct RegModels
    {
        /// <summary>
        /// Creates a memory operand
        /// </summary>
        /// <param name="src">The defining source value</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline)]
        public static mem<T> mem<T>(T src)
            where T : unmanaged
                => new mem<T>(src);

        [MethodImpl(Inline), Op]
        public m8 m8(Cell8 value)
            => new m8(value);

        [MethodImpl(Inline), Op]
        public m16 m16(Cell16 value)
            => new m16(value);

        [MethodImpl(Inline), Op]
        public m32 m32(Cell32 value)
            => new m32(value);

        [MethodImpl(Inline), Op]
        public m64 m64(Cell64 value)
            => new m64(value);

        [Op, Closures(UnsignedInts)]
        public static string format<T>(IReg<T> src)
            where T : unmanaged
        {
            switch(src.Width)
            {
                case NativeSizeCode.W8:
                    return format(src as IReg8<T>);
                case NativeSizeCode.W16:
                    return format(src as IReg16<T>);
                case NativeSizeCode.W32:
                    return format(src as IReg32<T>);
                case NativeSizeCode.W64:
                    return format(src as IReg64<T>);
                default:
                    var data = bytes(src.Content);
                    var formatter = HexFormatter.formatter<byte>();
                    return formatter.Format(data);
            }
        }

        [Op, Closures(UInt8k)]
        public static string format<T>(IReg8<T> src)
            where T : unmanaged
                => bw8(src.Content).FormatHex(specifier:false);

        [Op, Closures(UInt16k)]
        public static string format<T>(IReg16<T> src)
            where T : unmanaged
                => bw16(src.Content).FormatHex(specifier:false);

        [Op, Closures(UInt32k)]
        public static string format<T>(IReg32<T> src)
            where T : unmanaged
                => bw32(src.Content).FormatHex(specifier:false);

        [Op, Closures(UInt64k)]
        public static string format<T>(IReg64<T> src)
            where T : unmanaged
                => bw64(src.Content).FormatHex(specifier:false);
    }
}