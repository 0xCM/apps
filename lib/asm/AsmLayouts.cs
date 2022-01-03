//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static AsmLayoutModels;

    [ApiHost]
    public readonly partial struct AsmLayouts
    {
        [Op]
        public static uint render(in Layout0 src, Span<char> dst)
        {
            var i=0u;
            seek(dst, i++) = Chars.LBracket;
            AsmBits.rex(src.Rex, ref i, dst);
            seek(dst, i++) = Chars.Space;
            seek(dst, i++) = Chars.Pipe;
            seek(dst, i++) = Chars.Space;
            AsmBits.opcode(src.OpCode, ref i, dst);
            seek(dst, i++) = Chars.Space;
            seek(dst, i++) = Chars.Pipe;
            seek(dst, i++) = Chars.Space;
            AsmBits.modrm(src.ModRm, ref i, dst);
            seek(dst, i++) = Chars.Space;
            seek(dst, i++) = Chars.Pipe;
            seek(dst, i++) = Chars.Space;
            AsmBits.sib(src.Sib, ref i, dst);
            seek(dst,i++) = Chars.RBracket;
            return i;
        }

    }
}