//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Seq
    {
        public static string format<T>(T[] src, char delimiter = Chars.Comma, int pad = 0)
            => delimit<T>(delimiter, pad, @readonly(src)).Format();
    }
}