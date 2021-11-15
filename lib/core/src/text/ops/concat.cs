//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    partial struct TextTools
    {
        [Op]
        public static string concat(ReadOnlySpan<string> src, char? delimiter)
        {
            var dst = buffer();
            for(var i=0; i<src.Length; i++)
            {
                if(i != 0 && delimiter != null)
                    dst.Append(delimiter.Value);

                dst.Append(skip(src,i));
            }
            return dst.ToString();
        }

        [Op]
        public static string concat(ReadOnlySpan<string> src, string sep)
        {
            var dst = buffer();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i != 0 && sep != null)
                    dst.Append(sep);

                dst.Append(skip(src,i));
            }
            return dst.ToString();
        }
    }
}