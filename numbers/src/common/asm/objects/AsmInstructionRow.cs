//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmInstructionRow : ISequential<AsmInstructionRow>, IComparable<AsmInstructionRow>
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 7;

        [Render(ColWidths.Seq)]
        public uint Seq;

        [Render(ColWidths.DocSeq)]
        public uint DocSeq;

        [Render(ColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(ColWidths.OriginName)]
        public @string OriginName;

        [Render(32)]
        public Identifier AsmName;

        [Render(ColWidths.AsmExpr)]
        public AsmExpr Asm;

        [Render(1)]
        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => AsmName.IsEmpty && OriginId == 0;
        }

        public int CompareTo(AsmInstructionRow src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result==0)
                return DocSeq.CompareTo(src.DocSeq);
            return result;
        }

        // public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
        //     ColWidths.Seq,
        //     ColWidths.DocSeq,
        //     ColWidths.OriginId,
        //     ColWidths.OriginName,
        //     32,
        //     ColWidths.AsmExpr,
        //     1
        //     };

        public static AsmInstructionRow Empty => default;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}