//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow : ISequential, IOriginated, IComparable<AsmSyntaxRow>
    {
        public const string TableId = "asm.syntax";

        public const byte FieldCount = 8;

        public uint Seq;

        public Hex32 OriginId;

        public @string OriginName;

        public uint DocSeq;

        public AsmExpr Asm;

        public @string Syntax;

        public AsmHexCode Encoded;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        Hex32 IOriginated.OriginId
            => OriginId;

        public int CompareTo(AsmSyntaxRow src)
        {
            var result = Source.Path.FileName.CompareTo(src.Source.Path.FileName);
            if(result==0)
                return DocSeq.CompareTo(src.DocSeq);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,42,8,62,120,48,1};
    }
}