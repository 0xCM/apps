//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct AsmFormRecord : IComparable<AsmFormRecord>
    {
        public const string TableId = "sdm.forms";

        public const byte FieldCount = 7;

        public uint Seq;

        public Hex32 Token;

        public AsmMnemonic Mnemonic;

        public Identifier Kind;

        public AsmOpCode OpCode;

        public AsmSigExpr Sig;

        public AsmSigExpr Source;

        public int CompareTo(AsmFormRecord src)
        {
            var result = Kind.CompareTo(src.Kind);
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,12,16,42,42,62,1};

        public AsmFormSpec FormSpec()
            => new AsmFormSpec(Kind, Sig, OpCode);
    }
}