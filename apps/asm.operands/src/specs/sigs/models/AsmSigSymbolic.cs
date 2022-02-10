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

        public const byte FieldCount = 4;

        public uint Seq;

        public Identifier Name;

        public AsmSigExpr Source;

        public AsmSigRuleExpr Target;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,42,64,1};
    }
}