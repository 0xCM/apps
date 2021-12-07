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
        public static AsmText pinsrb_opcode(N0 n)
            => AsmText.opcode("66 0F 3A 20 /r ib");

        [MethodImpl(Inline), Op]
        public static AsmText pinsrb_sig(N0 n)
            => AsmText.sig("PINSRB xmm1, r32/m8, imm8");

        [MethodImpl(Inline), Op]
        public static AsmText pinsrb_rule(N0 n)
            => AsmText.rule("ModRM:reg (w) | ModRM:r/m (r) | imm8");
    }
}