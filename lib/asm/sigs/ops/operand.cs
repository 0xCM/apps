//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        [MethodImpl(Inline), Op]
        public static ref readonly AsmSigOpExpr operand(in AsmSigExpr src, byte i)
        {
            if(i==4)
                return ref src.Op4;
            if(i==3)
                return ref src.Op3;
            if(i==2)
                return ref src.Op2;
            if(i==1)
                return ref src.Op1;
            return ref src.Op0;
        }
    }
}