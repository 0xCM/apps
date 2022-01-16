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
    public struct AsmInstructionRow : ISequential
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public @string SrcId;

        public AsmId AsmId;

        public AsmExpr Asm;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,32,32,64,1};
    }
}