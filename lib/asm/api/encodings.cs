//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct asm
    {
        /// <summary>
        /// Computes the distinct encodings from the source
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static SortedSpan<AsmEncodingInfo> encodings(ReadOnlySpan<ProcessAsmRecord> src)
        {
            var collected = hashset<AsmEncodingInfo>();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                if(collected.Add(encoding(skip(src,i))))
                    counter++;
            }
            return collected.Array().ToSortedSpan();
        }
    }
}