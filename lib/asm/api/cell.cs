//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell cell(string content, AsmPartKind kind)
            => new AsmCell(default, kind, content);
    }
}