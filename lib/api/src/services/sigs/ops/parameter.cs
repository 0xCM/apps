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
        public static ApiSigTypeParam parameter(ushort position, Name name)
            => new ApiSigTypeParam(position, name);

        [MethodImpl(Inline), Op]
        public static ApiSigTypeParam parameter(ushort position, Name name, ApiTypeSig closure)
            => new ApiSigTypeParam(position, name, closure);
    }
}