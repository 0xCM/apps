//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct AsciBlocks
    {
        [MethodImpl(Inline), Op]
        public static ref AsciBlock4 encode(string src, out AsciBlock4 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock8 encode(string src, out AsciBlock8 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock16 encode(string src, out AsciBlock16 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock32 encode(string src, out AsciBlock32 dst)
            => ref encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static ref AsciBlock64 encode(string src, out AsciBlock64 dst)
            => ref encode(span(src), out dst);
    }
}