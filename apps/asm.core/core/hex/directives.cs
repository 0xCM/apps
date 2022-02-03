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
            => AsmDirective.define(".byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective word(Hex16 src)
            => AsmDirective.define(".2byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective dword(Hex32 src)
            => AsmDirective.define(".4byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective qword(Hex64 src)
            => AsmDirective.define(".8byte", src);
    }
}