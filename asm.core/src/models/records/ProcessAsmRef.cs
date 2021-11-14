//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines an IP location with context
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ProcessAsmRef : IRecord<ProcessAsmRef>
    {
        public const string TableId = "asm.global.ref";

        public const byte FieldCount = 5;

        /// <summary>
        /// A 0-based monotonic value that serves as a surrogate key
        /// </summary>
        public uint Sequence;

        /// <summary>
        /// A 0-based 32-bit offset
        /// </summary>
        public Address32 GlobalOffset;

        /// <summary>
        /// The IP block address
        /// </summary>
        public MemoryAddress BlockAddress;

        /// <summary>
        /// The IP address
        /// </summary>
        public MemoryAddress IP;

        /// <summary>
        /// The block-relative IP offset
        /// </summary>
        public Address16 BlockOffset;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,16,16,16,16};
    }
}