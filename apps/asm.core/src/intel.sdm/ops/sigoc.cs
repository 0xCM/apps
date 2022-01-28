//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SdmOps
    {
        [MethodImpl(Inline), Op]
        public static AsmFormExpr form(in SdmOpCodeDetail src)
            => asm.form(sig(src), src.OpCode);
    }
}