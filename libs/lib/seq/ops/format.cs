//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public static string format<T>(T[] src, char delimiter = Chars.Comma, int pad = 0)
            => Algs.delimit<T>(delimiter, pad, Arrays.@readonly(src)).Format();
    }
}