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

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns the label representation of the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static Label label(ReadOnlySpan<char> src, int offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && strings.store(src, offset, dst))
                return new Label(dst.Address(offset), (byte)length);
            else
                return Label.Empty;
        }

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns the label representation of the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static Label label(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && strings.store(src, offset, dst))
                return new Label(dst.Address(offset), (byte)length);
            else
                return Label.Empty;
        }
    }
}