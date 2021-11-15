//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmDataBlock
    {
        public const string TableId = "asm.blocks";

        public const byte FieldCount = 9;

        public uint Key;

        public MemoryAddress BlockAddress;

        public MemoryAddress IP;

        public Address16 BlockOffset;

        public CharBlock64 Expression;

        public CharBlock48 Encoded;

		public CharBlock64 Sig;

        public CharBlock32 OpCode;

        public CharBlock128 Bitstring;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16, 16, 16, 16, 64, 48, 64, 32, 128};
    }
}