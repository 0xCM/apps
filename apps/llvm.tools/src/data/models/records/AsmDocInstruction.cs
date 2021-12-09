//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmDocInstruction
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 5;

        public uint Seq;

        public uint DocSeq;

        public text31 Instruction;

        public AsmExpr Statement;

        public FS.FileUri Doc;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,32,64,1};

    }
}