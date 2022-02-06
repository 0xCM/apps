//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitfieldSeg<T> segment<T>(T src, byte offset, byte width)
            where T : unmanaged
                => new BitfieldSeg<T>(src, offset, width);
    }
}