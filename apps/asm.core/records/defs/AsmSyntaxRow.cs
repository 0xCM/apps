//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow : IComparable<AsmSyntaxRow>
    {
        public const string TableId = "asm.syntax";

        public const byte FieldCount = 8;

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public @string OriginName;

        public AsmExpr Asm;

        public @string Syntax;

        public AsmHexCode Encoded;

        public FS.FileUri Source;

        public AsmRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public int CompareTo(AsmSyntaxRow src)
        {
            var result = Source.Path.FileName.CompareTo(src.Source.Path.FileName);
            if(result==0)
                return DocSeq.CompareTo(src.DocSeq);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            AsmColWidths.Seq,
            AsmColWidths.DocSeq,
            AsmColWidths.OriginId,
            AsmColWidths.OriginName,
            AsmColWidths.AsmExpr,
            AsmColWidths.AsmSyntax,
            AsmColWidths.Encoded,
            1};

        public static AsmSyntaxRow Empty => default;
    }
}