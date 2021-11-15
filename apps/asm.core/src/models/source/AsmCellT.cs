//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmCell<T>
    {
        public byte Position {get;}

        public T Content {get;}

        public AsmCellKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmCell(byte pos, T data, AsmCellKind kind)
        {
            Content = data;
            Position = pos;
            Kind = kind;
        }
    }
}