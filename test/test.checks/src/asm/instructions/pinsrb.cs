//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmCaseArchive
    {
        [MethodImpl(Inline), Op]
        public static ResText pinsrb_opcode(N0 n)
            => ResText.from("66 0F 3A 20 /r ib");

        [MethodImpl(Inline), Op]
        public static ResText pinsrb_sig(N0 n)
            => ResText.from("PINSRB xmm1, r32/m8, imm8");
    }
}