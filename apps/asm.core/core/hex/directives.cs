//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmHexSpecs
    {
        [MethodImpl(Inline), Op]
        public static AsmDirective @byte(Hex8 src)
            => asm.directive(".byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective word(Hex16 src)
            => asm.directive(".2byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective dword(Hex32 src)
            => asm.directive(".4byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective qword(Hex64 src)
            => asm.directive(".8byte", src);
    }
}