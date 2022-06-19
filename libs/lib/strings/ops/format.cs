//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct strings
    {

        [MethodImpl(Inline), Op]
        public static unsafe string format(StringAddress src)
            => new string(src.Address.Pointer<char>());

        [MethodImpl(Inline), Op]
        public static unsafe string format<N>(StringAddress<N> src)
            where N : unmanaged, ITypeNat
                => new string(src.Address.Pointer<char>());
    }
}