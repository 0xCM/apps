//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Z0.Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmCallRow : IComparableRecord<AsmCallRow>
    {
        public const string TableId = "asm.calls";

        public const byte FieldCount = 8;

        /// <summary>
        /// The invoking part
        /// </summary>
        public PartId SourcePart;

        /// <summary>
        /// The block base address
        /// </summary>
        public MemoryAddress Block;

        /// <summary>
        /// The callsite IP
        /// </summary>
        public MemoryAddress Source;

        /// <summary>
        /// The destination address
        /// </summary>
        public MemoryAddress Target;

        /// <summary>
        /// The call instruction size
        /// </summary>
        public ByteSize InstructionSize;

        /// <summary>
        /// Target - (Source + InstructionSize)
        /// </summary>
        public MemoryAddress TargetOffset;

        /// <summary>
        /// The call statement
        /// </summary>
        public AsmExpr Instruction;

        /// <summary>
        /// The statement encoding
        /// </summary>
        public BinaryCode Encoded;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,16,16,16,36,16};

        [MethodImpl(Inline)]
        public int CompareTo(AsmCallRow src)
            => Target.CompareTo(src.Target);
    }
}