//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline)]
        public static BitfieldInterval interval(byte offset, byte width)
            => new BitfieldInterval(offset,width);
    }
}