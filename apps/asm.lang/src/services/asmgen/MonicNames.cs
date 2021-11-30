//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class AsmModelGen
    {
        public static string MonicFactoryName(string src)
        {
            var identifier = src.ToLowerInvariant();
            return identifier switch{
                "in" => "@in",
                "out" => "@out",
                "int" => "@int",
                "lock" => "@lock",
                _ => identifier
            };
        }

        public static string captitalize(string src)
        {
            var count = src.Length;
            Span<char> dst = stackalloc  char[count];
            var input = span(src.ToLowerInvariant());
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(input,i);
                if(i==0)
                    seek(dst,i) = c.ToUpper();
                else
                    seek(dst,i) = c;
            }
            return new string(dst);
        }
    }
}