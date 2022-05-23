//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HostAsmRecord : IRecord<HostAsmRecord>, IComparable<HostAsmRecord>
    {
        public const string TableId = "asm.statements";

        public const byte FieldCount = 9;

        public MemoryAddress BlockAddress;

        public MemoryAddress IP;

        public Address16 BlockOffset;

        public AsmExpr Expression;

        public AsmHexCode Encoded;

		public AsmSigInfo Sig;

        public AsmOpCodeString OpCode;

        public string Bitstring;

        public OpUri OpUri;

        public bool IsValid()
            => Expression.IsValid;

        [MethodImpl(Inline)]
        public int CompareTo(HostAsmRecord src)
            => IP.CompareTo(src.IP);

        public string Format()
            => string.Format("{0} {1,-36} # {2} => {3}",
                        BlockOffset,
                        Expression,
                        string.Format("({0})<{1}>[{2}] => {3}", Sig, OpCode, Encoded.Size, Encoded.Format()),
                        Encoded.BitString
                        );

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,64,32,64,32,128,80};
    }
}