//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct vbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte segwidth<T>(in Bitfield256<T> src, byte index)
            where T : unmanaged
                => cpu.vcell(src.Widths, index);

        [MethodImpl(Inline)]
        public static byte segwidth<E,T>(in Bitfield256<E,T> src, E index)
            where E : unmanaged
            where T : unmanaged
                => cpu.vcell(src.Widths, bw8(index));

        /// <summary>
        /// Defines widths for up to 32 symbol-identified bitfield segments
        /// </summary>
        /// <param name="w"></param>
        /// <param name="symbols"></param>
        /// <typeparam name="F"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<byte> segwidths<F>(W256 w, Symbols<F> symbols)
            where F : unmanaged
        {
            var values = symbols.Kinds;
            var widths = values.Bytes();
            var count = min(values.Length, 32);
            var data = default(Vector256<byte>);
            for(var i=0; i<count; i++)
                data = data.WithElement(i, u8(skip(values,i)));
            return data;
        }
    }
}
