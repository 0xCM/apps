//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SdmOps
    {
        [MethodImpl(Inline), Op]
        public static AsmForm form(in SdmOpCodeDetail src)
            => asm.form(sig(src), src.OpCode);
    }
}