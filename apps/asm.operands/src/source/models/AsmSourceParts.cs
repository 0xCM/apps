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

    using P = AsmPartKind;

    [ApiHost]
    public readonly struct AsmSourceParts
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static ReadOnlySpan<AsmPartKind> parts(AsmPartKind src)
        {
            var storage = ByteBlock12.Empty;
            var dst = recover<AsmPartKind>(storage.Bytes);
            var i = 0;

            if(BlockLabel(src))
                seek(dst,i++) = P.BlockLabel;

            if(OffsetLabel(src))
                seek(dst,i++) = P.OffsetLabel;

            if(Statement(src))
                seek(dst,i++) = P.Instruction;

            if(Comment(src))
                seek(dst,i++) = P.Comment;

            if(CodeSize(src))
                seek(dst,i++) = P.CodeSize;

            if(HexCode(src))
                seek(dst,i++) = P.HexCode;

            if(Sig(src))
                seek(dst,i++) = P.Sig;

            if(OpCode(src))
                seek(dst,i++) = P.OpCode;

            if(BitCode(src))
                seek(dst,i++) = P.BitCode;

            return slice(dst,0,i);
        }

        [MethodImpl(Inline), Op]
        public static bit BlockLabel(AsmPartKind src)
            => (src & AsmPartKind.BlockLabel) != 0;

        [MethodImpl(Inline), Op]
        public static bit OffsetLabel(AsmPartKind src)
            => (src & AsmPartKind.OffsetLabel) != 0;

        [MethodImpl(Inline), Op]
        public static bit Statement(AsmPartKind src)
            => (src & AsmPartKind.Instruction) != 0;

        [MethodImpl(Inline), Op]
        public static bit Comment(AsmPartKind src)
            => (src & AsmPartKind.Comment) != 0;

        [MethodImpl(Inline), Op]
        public static bit CodeSize(AsmPartKind src)
            => (src & AsmPartKind.CodeSize) != 0;

        [MethodImpl(Inline), Op]
        public static bit HexCode(AsmPartKind src)
            => (src & AsmPartKind.HexCode) != 0;

        [MethodImpl(Inline), Op]
        public static bit Sig(AsmPartKind src)
            => (src & AsmPartKind.Sig) != 0;

        [MethodImpl(Inline), Op]
        public static bit OpCode(AsmPartKind src)
            => (src & AsmPartKind.OpCode) != 0;

        [MethodImpl(Inline), Op]
        public static bit BitCode(AsmPartKind src)
            => (src & AsmPartKind.BitCode) != 0;
    }
}