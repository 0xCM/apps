//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class AsmSpecs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JccInfo<K> jcc<K>(K kind, text7 name, NativeSize size)
            where K : unmanaged
                => new JccInfo<K>(kind, name, size);

        [MethodImpl(Inline), Op]
        public static byte jo(Hex8 cb, ref byte hex)
        {
            const byte OpCode = 0x70;
            const byte Size = 2;
            seek(hex,0) = OpCode;
            seek(hex,1) = cb;
            return Size;
        }

        [MethodImpl(Inline), Op]
        public static byte jo(Hex32 cb, ref byte hex)
        {
            const ushort OpCode = 0x7080;
            const byte Size = 6;
            seek16(hex,0) = OpCode;
            seek32(hex,1) = cb;
            return Size;
        }
    }
}