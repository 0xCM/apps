//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public struct AsmSigOpTerm
    {
        public const byte FieldCount = 4;

        public AsmSigOp Op;

        public AsmSigOp Term0;

        public AsmSigOp Term1;

        public AsmSigOp Term2;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,12,12};
    }

}