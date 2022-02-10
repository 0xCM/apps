//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Record(TableId)]
    public struct AsmSigSymbolic
    {
        public const string TableId = "sdm.sigs.symbolic";

        public const byte FieldCount = 6;

        public uint Seq;

        public uint OcSeq;

        public Identifier Name;

        public AsmOpCode OpCode;

        public AsmSigExpr Source;

        public AsmSigExpr Target;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,42,42,64,1};
    }
}