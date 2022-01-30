//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct SdmFormRecord
    {
        public const string TableId = "sdm.forms";

        public const byte FieldCount = 4;

        public uint Seq;

        public Identifier SigId;

        public AsmSigExpr Sig;

        public AsmOpCode OpCode;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,42,62,1};
    }
}