//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmEncoding
    {
        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte src)
            => new ModRm(src);

        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte rm, byte reg, byte mod)
            => new ModRm(combine((rm, 0), (reg, 3), (mod, 6)));

        [MethodImpl(Inline), Op]
        public static ModRm modrm(RegIndex r1, RegIndex r2)
            => modrm((byte)r1, (byte)r2, 0b11);

        [MethodImpl(Inline), Op]
        public static ModRm modrm(RegIndex rm, RegIndex reg, byte mod)
            => modrm((byte)rm, (byte)reg, mod);
    }
}