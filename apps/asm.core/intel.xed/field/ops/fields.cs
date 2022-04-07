//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static Fields fields(Span<byte> src)
            => new Fields(recover<Field>(src));

        [MethodImpl(Inline), Op]
        public static Fields fields(Span<Field> src)
            => new Fields(src);

        [MethodImpl(Inline), Op]
        public static Fields fields(Span<uint> src)
            => new Fields(recover<Field>(src));

        [MethodImpl(Inline), Op]
        public static Fields fields(PageBlock2 src)
            => new Fields(src);

        [MethodImpl(Inline), Op]
        public static Fields fields()
            => new Fields(default(PageBlock2));
    }
}