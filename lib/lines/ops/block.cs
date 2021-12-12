//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static LineBlock block(in TextArea area, TextLine[] lines)
            => new LineBlock(area,lines);

        [MethodImpl(Inline), Op]
        public static LineBlocks blocks(TextArea[] areas, TextLine[] lines)
            => new LineBlocks(areas,lines);
    }
}