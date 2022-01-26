//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class AsmSigOpExprSet
    {
        public readonly byte OperandIndex;

        public readonly Index<AsmSigOpExpr> Expressions;

        [MethodImpl(Inline)]
        public AsmSigOpExprSet(byte op, AsmSigOpExpr[] expr)
        {
            OperandIndex = op;
            Expressions = expr;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOpExprSet((byte op, AsmSigOpExpr[] expr) src)
            => new AsmSigOpExprSet(src.op, src.expr);
    }
}