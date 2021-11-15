//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmCell
    {
        public byte Position {get;}

        public BinaryCode Content {get;}

        public AsmCellKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmCell(byte pos, BinaryCode data, AsmCellKind kind)
        {
            Content = data;
            Position = pos;
            Kind = kind;
        }
    }
}