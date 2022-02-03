//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    using static Hex8Kind;

    partial class AsmBytes
    {
        /// <summary>
        /// (AND AL, imm8)[24 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public static byte and(al r, imm8 imm8, Span<byte> dst)
        {
            var i = z8;
            seek(dst, i++) = (byte)x24;
            seek(dst,i++) = imm8;
            return i;
        }
    }
}