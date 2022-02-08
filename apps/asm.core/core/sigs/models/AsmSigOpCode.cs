//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Record(TableId)]
    public struct AsmSigOpCode : IComparable<AsmSigOpCode>
    {
        public const string TableId = "sdm.sigs";

        public const byte FieldCount = 9;

        public uint Seq;

        public Identifier Identity;

        public AsmSigExpr Sig;

        public CharBlock36 OpCode;

        public AsmSigOpExpr Op0;

        public AsmSigOpExpr Op1;

        public AsmSigOpExpr Op2;

        public AsmSigOpExpr Op3;

        public AsmSigOpExpr Op4;

        public int CompareTo(AsmSigOpCode src)
            => Identity.CompareTo(src.Identity);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,32,48,36,20,20,20,20,20};
    }
}