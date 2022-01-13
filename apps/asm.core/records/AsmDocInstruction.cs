//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmDocInstruction : ISequential
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 6;

        public uint Seq;

        public uint DocSeq;

        public @string SrcId;

        public text31 Instruction;

        public AsmExpr Asm;

        public FS.FileUri Doc;

        uint ISequential.Seq
            => Seq;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,32,32,64,1};
    }
}