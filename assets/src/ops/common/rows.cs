//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Resources
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<StringResRow> rows(ReadOnlySpan<StringRes> src)
            => src.Select(r => row(r));
    }
}