//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow : ISequential
    {
        public const string TableId = "asm.syntax";

        public const byte FieldCount = 9;

        public uint Seq;

        public Hex64 Id;

        public Hex32 DocId;

        public uint DocSeq;

        public AsmExpr Asm;

        public @string Syntax;

        public MemoryAddress IP;

        public AsmHexCode Encoded;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id == 0 && DocId == 0;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,12,8,62,120,12,48,5};
    }
}