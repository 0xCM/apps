//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct AsmCells
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell<T> cell<T>(byte pos, T content, AsmCellKind kind)
            => new AsmCell<T>(pos,content,kind);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell cell(byte pos, BinaryCode content, AsmCellKind kind)
            => new AsmCell(pos, content, kind);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmCell<T> typed<T>(AsmCell src)
            where T : struct
        {
            var data = recover<T>(bytes(src.Content.View));
            ref readonly var content = ref first(data);
            return new AsmCell<T>(src.Position, content, src.Kind);
        }
    }
}