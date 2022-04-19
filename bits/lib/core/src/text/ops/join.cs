//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct TextTools
    {
        public static string join(string sep, Span<string> src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Length; i++)
            {
                ref var cell = ref src[i];
                if(i != src.Length - 1)
                    dst.Append($"{cell}{sep}");
                else
                    dst.Append(cell);
            }
            return dst.ToString();
        }
    }
}