//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiOperationSig operation(Name name, ApiOperandSig @return, params ApiOperandSig[] operands)
            => new ApiOperationSig(name, @return, operands);
    }
}