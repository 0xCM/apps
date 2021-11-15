//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Nasm
    {
        [MethodImpl(Inline), Op]
        public static NasmCaseScript script(NasmCase @case, FS.FilePath src)
            => new NasmCaseScript(@case, src);
    }
}