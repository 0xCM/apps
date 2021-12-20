//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EnumCoverParser<E> : IParser<EnumCover<E>>
        where E : unmanaged, Enum
    {
        readonly EnumParser<E> Parser;

        public EnumCoverParser()
        {
            Parser = new();
        }

        public Outcome Parse(string src, out EnumCover<E> dst)
        {
            var result = Parser.Parse(src, out var e);
            if(result)
                dst = e;
            else
                dst = default;
            return result;
        }
    }
}