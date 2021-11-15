//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOperands;
    using static asm;

    partial class AsmSpecs
    {
        /// <summary>
        /// EVEX.128.F3.0F38.W0 30 /r | VPMOVWB xmm1/m64 {k1}{z}, xmm2
        /// </summary>
        /// <param name="xmm1"></param>
        /// <param name="k"></param>
        /// <param name="z"></param>
        /// <param name="xmm2"></param>
        /// <param name="hex"></param>
        [MethodImpl(Inline), Op]
        public static byte vmpovwb(xmm xmm1, rK k, bit z, xmm xmm2, ref byte hex)
        {
            return 0;
        }
    }
}