//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableCell : ITextual
    {
        public object Content {get;}

        [MethodImpl(Inline)]
        public TableCell(object content)
        {
            Content = content;
        }

        public string Format()
            => Content != null ? Content.ToString() : RP.Null;

        public override string ToString()
            => Format();
    }
}