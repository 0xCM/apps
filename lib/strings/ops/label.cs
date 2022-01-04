//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct strings
    {
        /// <summary>
        /// Creates a label from an embedded string
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Label label(string src)
        {
            if(core.empty(src))
                return Label.Empty;
            StringAddress a = src;
            return new Label(a.Address, (byte)src.Length);
        }

        /// <summary>
        /// Creates a label from an embedded/fixed character span
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Label label(ReadOnlySpan<char> src)
            => new Label(address(src), (byte)src.Length);
    }
}