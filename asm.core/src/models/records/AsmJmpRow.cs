//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using Z0.Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmJmpRow : IRecord<AsmJmpRow>
    {
        public const string TableId = "asm.jumps";

        public const byte FieldCount = 9;

        public PartId SourcePart;

        public MemoryAddress Block;

        public MemoryAddress Source;

        public ByteSize InstructionSize;

        public MemoryAddress CallSite;

        public MemoryAddress Target;

        public JmpKind Kind;

        public AsmExpr Instruction;

        public BinaryCode Encoded;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,16,16,16,12,26,26};
    }
}