//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiSigTypeParam parameter(ushort position, NameOld name)
            => new ApiSigTypeParam(position, name);

        [MethodImpl(Inline), Op]
        public static ApiSigTypeParam parameter(ushort position, NameOld name, ApiTypeSig closure)
            => new ApiSigTypeParam(position, name, closure);
    }
}