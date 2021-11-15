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

    using api = BitfieldSpecs;

    /// <summary>
    /// Defines an identified, contiguous bitsequence, represented symbolically as {Identifier}:[Min,Max]
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct BitfieldSegModel
    {
        /// <summary>
        /// The segment name
        /// </summary>
        public readonly Identifier Name;

        /// <summary>
        /// The 0-based position of the segment within the field
        /// </summary>
        public readonly uint Index;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly uint Offset;

        /// <summary>
        /// The index, of the last bit in the segment
        /// </summary>
        public readonly uint Width;

        [MethodImpl(Inline)]
        public BitfieldSegModel(Identifier name, uint pos,  uint offset, uint width)
        {
            Name = name;
            Index = pos;
            Offset = offset;
            Width = width;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}