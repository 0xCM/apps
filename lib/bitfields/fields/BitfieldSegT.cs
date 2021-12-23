//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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

        public uint EndPos
        {
            [MethodImpl(Inline)]
            get => Bitfields.endpos(Offset,Width);
        }

        public string Format()
            => string.Format("[{0}:{1}] {2}", EndPos, Offset, core.bytes(Value).FormatBits());

        public override string ToString()
            => Format();
    }
}