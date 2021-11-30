//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string denullify<T>(T src)
            => src is null ? Null : src.ToString();
    }
}