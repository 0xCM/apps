//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public unsafe readonly struct Sigs
    {
        [MethodImpl(Inline), Op]
        public static delegate* unmanaged<int,int,int> func_32i_32i_32i(void* f)
            => (delegate* unmanaged<int,int,int>) f;

        [MethodImpl(Inline), Op]
        public static int invoke(delegate* unmanaged<int,int,int> f, int a, int b)
            => f(a,b);
    }
}