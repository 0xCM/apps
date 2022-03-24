//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct TextTools
    {
        [MethodImpl(Inline), Op]
        public static TextLine line(uint number, TextRow src)
            => new TextLine(number, src.RowText);
    }
}