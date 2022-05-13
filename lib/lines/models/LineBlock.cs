//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineBlock
    {
        public readonly TextArea Area {get;}

        public readonly Index<TextLine> Lines;

        [MethodImpl(Inline)]
        public LineBlock(TextArea area, TextLine[] lines)
        {
            Area = area;
            Lines = lines;
        }
    }
}