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
        public static SdmSigOpCode sigoc(in SdmOpCodeDetail src)
            => new SdmSigOpCode(sig(src), src.OpCode);
    }
}