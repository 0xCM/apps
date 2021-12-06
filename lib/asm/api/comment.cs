//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmComment comment(string src)
            => AsmDocBuilder.comment(src);

        [MethodImpl(Inline), Op]
        public static AsmInlineComment comment(AsmCommentMarker marker, string src)
            => AsmDocBuilder.comment(marker,src);
    }
}