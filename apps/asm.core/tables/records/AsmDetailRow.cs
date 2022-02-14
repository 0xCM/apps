//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmDetailRow : IRecord<AsmDetailRow>, IComparable<AsmDetailRow>
    {
        public const string TableId = "asm.rows";

        public const byte FieldCount = 12;

        public uint Sequence;

        public MemoryAddress BlockAddress;

        public MemoryAddress IP;

        public Address32 GlobalOffset;

        public Address16 LocalOffset;

		public AsmMnemonic Mnemonic;

		public AsmOpCodeString OpCode;

        public string Instruction;

        public string Statement;

        public AsmHexCode Encoded;

		public string CpuId;

        public string OpCodeId;

        [MethodImpl(Inline)]
        public int CompareTo(AsmDetailRow src)
            => Sequence.CompareTo(src.Sequence);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,16,16,16,16,32,32,32,32,32,32,32};
    }
}