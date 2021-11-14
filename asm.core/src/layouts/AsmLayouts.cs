//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;
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

        // [MethodImpl(Inline), Op]
        // public static Layout0 define(RexPrefix rex, Hex8 opcode, ModRm mrm, Sib sib)
        // {
        //     var dst = new Layout0();
        //     dst.Rex = rex;
        //     dst.OpCode = opcode;
        //     dst.ModRm = mrm;
        //     dst.Sib = sib;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Layout1 define(Hex8 src)
        // {
        //     var dst = new Layout1();
        //     dst.OpCode = src;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Layout2 define(Hex8 opcode, ModRm mrm)
        // {
        //     var dst = new Layout2();
        //     dst.OpCode = opcode;
        //     dst.ModRm = mrm;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Layout7 define(Hex8 opcode, Disp8 disp)
        // {
        //     var dst = new Layout7();
        //     dst.OpCode = opcode;
        //     dst.Disp = disp;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Layout8 define(Hex8 opcode, Disp16 disp)
        // {
        //     var dst = new Layout8();
        //     dst.OpCode = opcode;
        //     dst.Disp = disp;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Layout10 define(VexPrefix vex, Hex8 opcode, ModRm mrm)
        // {
        //     var dst = new Layout10();
        //     dst.Vex = vex;
        //     dst.OpCode = opcode;
        //     dst.ModRm = mrm;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Layout6 define(VexPrefix vex, Hex8 opcode, ModRm mrm, Sib sib)
        // {
        //     var dst = new Layout6();
        //     dst.Vex = vex;
        //     dst.OpCode = opcode;
        //     dst.ModRm = mrm;
        //     dst.Sib = sib;
        //     return dst;
        // }
    }
}