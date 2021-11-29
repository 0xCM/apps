//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class text
    {
        /// <summary>
        /// Compares two <see cref='string'/> operands via the default <see cref='IComparable'/> implementation
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [Op]
        public static int compare(string a, string b)
            => a?.CompareTo(b) ?? 0;

        /// <summary>
        /// Compares two <see cref='char'/> operands via the default <see cref='IComparable'/> implementation
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static int compare(char a, char b)
            => a.CompareTo(b);
    }
}