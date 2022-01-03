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

    using api = Bitfields;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct BitfieldSegModel<K>
        where K : unmanaged
    {
        /// <summary>
        /// The segment name
        /// </summary>
        public readonly Identifier SegName;

        /// <summary>
        /// The 0-based position of the segment within the field
        /// </summary>
        public readonly uint SegPos;

        /// <summary>
        /// The segment position within the field
        /// </summary>
        public readonly K SegId;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly uint MinIndex;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly uint MaxIndex;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly uint SegWidth;

        [MethodImpl(Inline)]
        public BitfieldSegModel(K id, uint pos, uint min, uint max)
        {
            SegPos = pos;
            SegName = id.ToString();
            SegId = id;
            MinIndex = min;
            MaxIndex = max;
            SegWidth = max - min + 1;
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();
    }
}