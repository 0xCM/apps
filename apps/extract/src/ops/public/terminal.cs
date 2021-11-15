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
    using static ExtractTermData;

    partial struct ApiExtracts
    {
        [Op]
        public static ExtractTermInfo terminal(ReadOnlySpan<byte> src)
        {
            const byte MaxSeg = 6;

            var size = src.Length;
            var found = NotFound;
            var max = size + MaxSeg - 1;
            var kind = ExtractTermKind.None;
            var modifier = z8i;
            for(var offset=0; offset<max; offset++)
            {
                if(slice(src, offset, 3).SequenceEqual(Term3A))
                {
                    found = offset;
                    kind = ExtractTermKind.Term3A;
                    modifier = Term3AModifier;
                    break;
                }
                else if(slice(src, offset, 6).SequenceEqual(Term6A))
                {
                    found = offset;
                    kind = ExtractTermKind.Term6A;
                    modifier = Term6AModifier;
                    break;
                }
                else if(slice(src, offset, 5).SequenceEqual(Term5A))
                {
                    found = offset;
                    kind = ExtractTermKind.Term5A;
                    modifier = Term5AModifier;
                    break;
                }
                else if(slice(src, offset, 4).SequenceEqual(Term4A))
                {
                    found = offset;
                    kind = ExtractTermKind.Term4A;
                    modifier = Term4AModifier;
                    break;
                }
                else if(slice(src, offset, 3).SequenceEqual(Term3B))
                {
                    found = offset;
                    kind = ExtractTermKind.Term3B;
                    modifier = Term3BModifier;
                    break;
                }
                else if(slice(src, offset, 4).SequenceEqual(Term4B))
                {
                    found = offset;
                    kind = ExtractTermKind.Term4B;
                    modifier = Term4BModifier;
                    break;
                }
            }

            return new ExtractTermInfo(kind, found, modifier);
        }
    }
}