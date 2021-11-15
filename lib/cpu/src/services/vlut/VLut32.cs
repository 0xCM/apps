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
    /// Implements a parallel 32-way lookup
    /// </summary>
    [ApiComplete]
    public readonly struct VLut32
    {
        internal readonly Vector256<byte> Mask;

        [MethodImpl(Inline)]
        public static VLut32 define(Vector256<byte> src)
            => new VLut32(src);

        [MethodImpl(Inline)]
        public static VLut32 define(ReadOnlySpan<byte> src)
            => new VLut32(src);

        [MethodImpl(Inline)]
        public static VLut32 define(in SpanBlock256<byte> src)
            => new VLut32(src);

        [MethodImpl(Inline)]
        public static implicit operator Vector256<byte>(in VLut32 src)
            => src.Mask;

        public byte this[byte i]
        {
            [MethodImpl(Inline)]
            get => cpu.vcell(Mask, i);
        }

        [MethodImpl(Inline)]
        public VLut32(Vector256<byte> src)
            => Mask = src;

        [MethodImpl(Inline)]
        public VLut32(in SpanBlock256<byte> src)
            => Mask = gcpu.vload(src);

        [MethodImpl(Inline)]
        public VLut32(ReadOnlySpan<byte> src)
            => Mask = gcpu.vload(w256,src);
    }
}