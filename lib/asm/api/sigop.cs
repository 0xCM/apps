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
        public static AsmSigOp sigop(AsmOpClass @class, AsmSigOpKind kind, NativeSize size)
            => new AsmSigOp(@class,kind,size);
    }
}