//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmCodeIndexRow : IOriginated
    {
        public const string TableId = "asm.index";

        public const byte FieldCount = 11;

        public uint Seq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public uint DocSeq;

        public Identifier AsmName;

        public MemoryAddress IP;

        public byte Size;

        public AsmHexCode Encoded;

        public AsmExpr Asm;

        public @string Syntax;

        public FS.FileUri Source;

        Hex32 IOriginated.OriginId
            => OriginId;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,16,12, 16,16,8,42,82,82,1};
    }
}