//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    using static Root;

    partial struct RP
    {
        /// <summary>
        /// Produces the literal '{<paramref name='index'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index)
            => string.Concat("{", index, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index, short pad)
            => string.Concat("{", index, ",", pad, "}");

        public static string slots(char delimiter, params short[] padding)
        {
            var dst = new StringBuilder();
            var count = padding.Length;
            for(byte i=0; i<count; i++)
            {
                dst.Append(slot(i, padding[i]));
                if(i != count - 1)
                {
                    dst.Append(Chars.Space);
                    dst.Append(delimiter);
                    dst.Append(Chars.Space);
                }
            }
            return dst.ToString();
        }
    }
}