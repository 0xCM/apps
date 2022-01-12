//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct SizedLocation
    {
        public readonly ushort Seq;

        public readonly ushort Size;

        public readonly uint Offset;

        [MethodImpl(Inline)]
        public SizedLocation(ushort seq, ushort size, uint offset)
        {
            Seq = seq;
            Size = size;
            Offset = offset;
        }

        public string Format()
            => string.Format("{0}:{1}:{2}", Seq.ToString("D4"), Size.FormatHex(), Offset.FormatHex(zpad:false));

        public override string ToString()
            => Format();
    }
}