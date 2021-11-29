//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static bool equals(char a, char b)
            => a == b;

        [MethodImpl(Inline), Op]
        public static bool equals(in SegRef<char> a, string b)
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            var match = true;
            ref readonly var left = ref a.First;
            ref readonly var right = ref first(span(b));
            for(var i=0; i<count; i++)
            {
                match &= (skip(left,i) == skip(right,i));
                if(!match)
                    break;
            }
            return match;
        }

        /// <summary>
        /// Performs a string comparison according to a specified comparison type
        /// </summary>
        /// <param name="a">The first string</param>
        /// <param name="b">The second string</param>
        /// <param name="type">The comparison type</param>
        [MethodImpl(Inline), Op]
        public static bool equals(string a, string b, StringComparison type)
            => string.Equals(a,b, type);

        /// <summary>
        /// Performs a case-insensitive comparison on two source strings
        /// </summary>
        /// <param name="a">The first string</param>
        /// <param name="b">The second string</param>
        [MethodImpl(Inline), Op]
        public static bool equals(string a, string b)
            => string.Equals(a,b, NoCase);

        /// <summary>
        /// Performs a string comparison according to a specified comparison type
        /// </summary>
        /// <param name="a">The first string</param>
        /// <param name="b">The second string</param>
        /// <param name="type">The comparison type</param>
        [MethodImpl(Inline), Op]
        public static bool neq(string a, string b, StringComparison type)
            => !equals(a, b, type);

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static bool equals(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            => a.CompareTo(b, StringComparison.InvariantCulture) == 0;

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static bool equals(Span<char> a, ReadOnlySpan<char> b)
            => equals(a.ReadOnly(), b);

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static bool equals(Span<char> a, Span<char> b)
            => equals(a.ReadOnly(), b.ReadOnly());
    }
}