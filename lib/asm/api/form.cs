//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmFormExpr form(in AsmSigExpr sig, in CharBlock36 oc)
            => new AsmFormExpr(sig, oc);

        [MethodImpl(Inline), Op]
        public static AsmForm form(Identifier name, in AsmSig sig, in AsmOpCode oc)
            => new AsmForm(name, sig, oc);
    }
}