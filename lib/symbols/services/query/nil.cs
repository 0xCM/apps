//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit nil(char src)
            => (char)(C.Null) == src;

        [MethodImpl(Inline), Op]
        public static bit nil(C src)
            => C.Null == src;

        [MethodImpl(Inline), Op]
        public static bit nil(byte src)
            => (byte)C.Null == src;
    }
}