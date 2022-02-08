//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmInstructionRow : ISequential
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 6;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public Identifier AsmName;

        public AsmExpr Asm;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,32,64,1};
    }
}