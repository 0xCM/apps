//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSpecs
    {
        [MethodImpl(Inline), Op]
        public static AsmDirective @byte(Hex8 src)
            => asm.directive(".byte", src);

        public static AsmDirective word(Hex16 src)
            => asm.directive(".byte2", src);

        public static AsmDirective dword(Hex32 src)
            => asm.directive(".byte4", src);

        public static AsmDirective qword(Hex64 src)
            => asm.directive(".byte8", src);
    }
}