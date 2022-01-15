//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmCell : IAsmSourcePart, INullity
    {
        /// <summary>
        /// The content origin
        /// </summary>
        public GridPoint<uint> Location {get;}

        public @string Content {get;}

        public AsmPartKind PartKind {get;}

        [MethodImpl(Inline)]
        public AsmCell(GridPoint<uint> loc, AsmPartKind kind, string content)
        {
            Location = loc;
            Content = content;
            PartKind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();
    }
}