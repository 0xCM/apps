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
        public static MemoryBlock memblock(in ApiMemberCode src, ExtractTermInfo term)
        {
            if(!term.TerminalFound)
                return MemoryBlock.Empty;

            var kind = term.Kind;
            var size = ByteSize.Zero;
            var modifier = skip(TermModifiers, (byte)kind);
            if(kind == ExtractTermKind.Term5A)
                size = term.Offset + modifier;
            else
                size = term.Offset;

            var origin = new MemoryRange(src.Address, size);
            var data = slice(src.Encoded.Bytes, 0, size);
            return new MemoryBlock(origin, data.ToArray());
        }
    }
}