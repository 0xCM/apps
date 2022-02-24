//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmInstructionRow : ISequential, IOriginated
    {
        public const string TableId = "asm.instruction";

        public const byte FieldCount = 6;

        public uint Seq;

        public Hex32 OriginId;

        public uint DocSeq;

        public Identifier AsmName;

        public AsmExpr Asm;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        Hex32 IOriginated.OriginId
            => OriginId;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => AsmName.IsEmpty && OriginId == 0;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,8,32,64,1};

    }
}