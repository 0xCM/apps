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
        public static void and(al r, imm8 imm8, AsmHexWriter dst)
        {
            dst.Write1(x24);
            dst.Write1(imm8);
        }
    }
}