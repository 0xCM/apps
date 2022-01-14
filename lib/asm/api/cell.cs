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
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static AsmCell<T> cell<T>(GridPoint<uint> loc, T content, AsmPartKind kind)
        //     => new AsmCell<T>(loc,kind, content);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell cell(GridPoint<uint> loc, string content, AsmPartKind kind)
            => new AsmCell(loc, kind, content);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static AsmCell<T> cell<T>(T content, AsmPartKind kind)
        //     => new AsmCell<T>(default, kind, content);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell cell(string content, AsmPartKind kind)
            => new AsmCell(default, kind, content);
    }
}