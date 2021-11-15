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
        /// Deposits a character sequence into a caller-supplied buffer and returns a reference to the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static StringRef @string(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && strings.store(src, offset, dst))
                return new StringRef(dst.Address(offset), (byte)length);
            else
                return StringRef.Empty;
        }
    }
}