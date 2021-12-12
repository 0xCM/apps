//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LineBlock
    {
        public TextArea Area {get;}

        public Index<TextLine> Lines {get;}

        [MethodImpl(Inline)]
        public LineBlock(TextArea area, TextLine[] lines)
        {
            Area = area;
            Lines = lines;
        }
    }
}