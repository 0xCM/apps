//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct strings
    {
        [MethodImpl(Inline), Op]
        public static unsafe ref char first(StringAddress src)
            => ref core.@ref(src.Address.Pointer<char>());
    }
}