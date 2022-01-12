//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial struct minicore
    {
        [MethodImpl(Inline)]
        public static bool nonempty(string src)
            => !string.IsNullOrWhiteSpace(src);
    }
}