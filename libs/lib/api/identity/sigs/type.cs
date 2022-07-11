//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiTypeSig type(NameOld name, params ISigTypeParam[] parameters)
            => new ApiTypeSig(name, parameters);
    }
}