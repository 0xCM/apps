//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public static partial class XAsci
    {
        [MethodImpl(Inline)]
        public static int FirstIndexOf<T>(this T src, AsciCharSym match)
            where T : IAsciSeq
                => AsciG.index(src, match);

        [MethodImpl(Inline)]
        public static bool Contains<T>(this T src, AsciCharSym match)
            where T : IAsciSeq
                => AsciG.contains(src, match);
    }
}
