//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmInstructionRow : ISequential, IComparable<AsmInstructionRow>
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public @string OriginName;

        public Identifier AsmName;

        public AsmExpr Asm;

        public FS.FileUri Source;

        public DocRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq);
        }

        uint ISequential.Seq
            => Seq;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => AsmName.IsEmpty && OriginId == 0;
        }

        public int CompareTo(AsmInstructionRow src)
        {
            var result = Source.Path.FileName.CompareTo(src.Source.Path.FileName);
            if(result==0)
                return DocSeq.CompareTo(src.DocSeq);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.Seq,
            ColWidths.DocSeq,
            ColWidths.OriginId,
            ColWidths.OriginName,
            32,
            64,
            1
            };

    }
}