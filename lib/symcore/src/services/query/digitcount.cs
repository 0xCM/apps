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

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static uint digitcount(Base16 @base, ReadOnlySpan<C> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(whitespace(c))
                {
                    if(counter == 0)
                        continue;
                }
                else
                    return counter;

                if(digit(@base, c))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of consecutive hex digits
        /// </summary>
        /// <param name="base"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static uint digitcount(Base16 @base, ReadOnlySpan<AsciSymbol> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(digit(@base, (AsciCode)c))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint digitcount(Base16 @base, ReadOnlySpan<char> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(whitespace(c))
                {
                    if(counter == 0)
                        continue;
                }
                else
                    return counter;

                if(digit(@base, c))
                    counter++;
                else
                    break;
            }
            return counter;
        }
    }
}