//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmCell<T> : IAsmSourcePart
    {
        /// <summary>
        /// The content origin
        /// </summary>
        public GridPoint<uint> Location {get;}

        public AsmPartKind PartKind {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public AsmCell(GridPoint<uint> loc, AsmPartKind kind, T data)
        {
            Location = loc;
            Content = data;
            PartKind = kind;
        }

        public string Format()
            => Content == null ? EmptyString : Content.ToString();

        public override string ToString()
            => Format();
    }
}