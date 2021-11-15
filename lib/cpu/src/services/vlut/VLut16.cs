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

    /// <summary>
    /// Implements a parallel 16-way lookup
    /// </summary>
    [ApiComplete]
    public readonly struct VLut16
    {
        internal readonly Vector128<byte> Mask;

        [MethodImpl(Inline)]
        public static VLut16 define(Vector128<byte> src)
            => new VLut16(src);

        [MethodImpl(Inline)]
        public static VLut16 define(ReadOnlySpan<byte> src)
            => new VLut16(src);

        [MethodImpl(Inline)]
        public static VLut16 define(in SpanBlock128<byte> src)
            => new VLut16(src);

        public byte this[byte i]
        {
             [MethodImpl(Inline)]
             get => cpu.vcell(Mask,i);
        }

        [MethodImpl(Inline)]
        VLut16(Vector128<byte> src)
            => Mask = src;

        [MethodImpl(Inline)]
        VLut16(in SpanBlock128<byte> src)
            => Mask = gcpu.vload(src);

        [MethodImpl(Inline)]
        VLut16(ReadOnlySpan<byte> src)
            => Mask = gcpu.vload(w128,src);

        [MethodImpl(Inline)]
        public static implicit operator Vector128<byte>(in VLut16 src)
            => src.Mask;
    }
}