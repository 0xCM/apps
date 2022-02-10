//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct SdmOps
    {
        [MethodImpl(Inline), Op]
        public static AsmFormExpr form(in SdmOpCodeDetail src)
            => AsmFormExpr.define(sig(src), src.OpCode);
    }
}