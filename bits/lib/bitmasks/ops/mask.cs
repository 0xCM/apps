//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMasks
    {
        [MethodImpl(Inline), Op]
        public static BitMask mask(W8 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.enable(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W16 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.enable(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W32 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.enable(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W64 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.enable(w, i0, i1));

        [Op]
        public static BitMask mask(NativeSize size, byte i0, byte i1)
            => size.Code switch{
                NativeSizeCode.W8 => mask(w8, i0, i1),
                NativeSizeCode.W16 => mask(w16, i0, i1),
                NativeSizeCode.W32 => mask(w32, i0, i1),
                NativeSizeCode.W64 => mask(w64, i0, i1),
                _ => BitMask.Empty
            };
    }
}