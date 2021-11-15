//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Z0.Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessAsmRecord : IRecord<ProcessAsmRecord>, IComparable<ProcessAsmRecord>, IAsmHexProvider<ProcessAsmRecord>
    {
        public const string TableId = "asm.global";

        public const byte FieldCount = 11;

        public const ushort RowPad = 680;

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

        public AsmExpr Statement;

        public AsmHexCode Encoded;

		public AsmSigInfo Sig;

        public AsmOpCodeString OpCode;

        public AsmBitstring Bitstring;

        public OpUri OpUri;

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode AsmHex(out AsmHexCode hex)
        {
            hex = Encoded;
            return ref hex;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ProcessAsmRecord src)
            => IP.CompareTo(src.IP);

        public override int GetHashCode()
            => (int)Sequence;

        [MethodImpl(Inline)]
        public ProcessAsmRef GetRef()
        {
            var dst = new ProcessAsmRef();
            dst.Sequence = Sequence;
            dst.GlobalOffset = GlobalOffset;
            dst.BlockAddress = BlockAddress;
            dst.IP = IP;
            dst.BlockOffset = BlockOffset;
            return dst;
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,16,16,16,16,42,32,42,32,128,80};
    }
}