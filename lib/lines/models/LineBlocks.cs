//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LineBlocks
    {
        public Index<TextArea> Areas {get;}

        readonly Index<TextLine> _Lines;

        [MethodImpl(Inline)]
        public LineBlocks(TextArea[] areas, TextLine[] lines)
        {
            Areas = areas;
            _Lines = lines;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<TextLine> Lines(uint index)
        {
            ref readonly var area = ref Areas[index];
            var i = area.MinLine - 1;
            var j = area.MaxLine - 1;
            return core.segment(_Lines.View, i, j);
        }
    }
}