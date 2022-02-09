//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell cell(string content, AsmPartKind kind)
            => new AsmCell(kind, content);
    }
}