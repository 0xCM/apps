//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Text;

    using static Root;

    partial class text
    {
        [Op]
        public static ITextBuffer buffer()
            => new TextBuffer(new StringBuilder());

        [Op]
        public static ITextBuffer buffer(uint capacity)
            => new TextBuffer(capacity);
    }
}
