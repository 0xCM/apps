//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static LineRange range(uint min, uint max, TextLine[] data)
            => new LineRange(min, max, data);
    }
}