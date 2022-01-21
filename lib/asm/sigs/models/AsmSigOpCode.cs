//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Record(TableId)]
    public struct AsmSigOpCode
    {
        public const string TableId = "sdm.sigs";

        public const byte FieldCount = 7;

        public uint Seq;

        public AsmSigExpr Sig;

        public AsmOpCode OpCode;

        public AsmSigOpExpr Op0;

        public AsmSigOpExpr Op1;

        public AsmSigOpExpr Op2;

        public AsmSigOpExpr Op3;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,48,36,20,20,20,20};
    }
}