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
        public static bool returns(ApiOperandSig src)
            => src.Name == ReturnIndicator;

        [MethodImpl(Inline), Op]
        public static ApiOperandSig @return(ApiTypeSig type, params ApiSigModKind[] modifiers)
            => new ApiOperandSig(ReturnIndicator, type, modifiers);
    }
}