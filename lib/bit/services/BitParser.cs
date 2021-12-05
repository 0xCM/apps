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

    [ApiHost]
    public readonly struct BitParser
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates a parser for bits values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitsParser<T> bits<T>()
            where T : unmanaged
                => default;

        [Op]
        public static bool semantic(string src, out bit dst)
        {
            const string On1 = "1";
            const string On2 = "true";
            const string On3 = "yes";
            const string On4 = "on";

            const string Off1 = "0";
            const string Off2 = "false";
            const string Off3 = "no";
            const string Off4 = "off";

            dst = default;

            if(empty(src))
                return false;

            var input = src.ToLowerInvariant();
            if(matches(input, On1))
            {
                dst = 1;
                return true;
            }

            if(matches(input, On2))
            {
                dst = 1;
                return true;
            }

            if(matches(input, On3))
            {
                dst = 1;
                return true;
            }

            if(matches(input, On4))
            {
                dst = 1;
                return true;
            }

            if(matches(input, Off1))
            {
                dst = 0;
                return true;
            }

            if(matches(input, Off2))
            {
                dst = 0;
                return true;
            }

            if(matches(input, Off3))
            {
                dst = 0;
                return true;
            }

            if(matches(input, Off4))
            {
                dst = 0;
                return true;
            }

            return false;
        }

        [MethodImpl(Inline), Op]
        static bool matches(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            for(var i=0; i<count; i++)
                if(skip(a,i) != skip(b, i))
                    return false;

            return true;
        }
    }
}