//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public class AsmSigOpExprSets
    {
        readonly Dictionary<byte, AsmSigOpExprSet> Data;

        public AsmSigOpExprSets()
        {
            Data = new();
        }


        public AsmSigOpExprSet this[byte i]
        {
            get => Data[i];
        }

        public AsmSigOpExprSet Include(byte i, Index<AsmSigOpExpr> expr)
        {
            var dst = new AsmSigOpExprSet(i,expr);
            Data[i] = dst;
            return dst;
        }
    }
}