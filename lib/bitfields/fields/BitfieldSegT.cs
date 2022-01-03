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

    [StructLayout(LayoutKind.Sequential)]
    public struct BitfieldSeg<T>
        where T : unmanaged
    {
        /// <summary>
        /// The segment value
        /// </summary>
        public T Value;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public uint Offset;

        /// <summary>
        /// The segment width
        /// </summary>
        public uint Width;

        [MethodImpl(Inline)]
        public BitfieldSeg(T value, uint offset, uint width)
        {
            Value = value;
            Offset = offset;
            Width = width;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Width == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Width != 0;
        }

        public uint EndPos
        {
            [MethodImpl(Inline)]
            get => Bitfields.endpos(Offset,Width);
        }


        public string Format()
            => string.Format("[{0}:{1}] {2}", EndPos, Offset, core.bytes(Value).FormatBits());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator T(BitfieldSeg<T> src)
            => src.Value;
        public static BitfieldSeg<T> Empty => default;
    }
}