//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SyntaxFragment : ITextual
    {
        /// <summary>
        /// The content origin
        /// </summary>
        public GridPoint<uint> Location {get;}

        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public SyntaxFragment(GridPoint<uint> location, TextBlock content)
        {
            Location = location;
            Content = content;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content.ToString();

        public override string ToString()
            => Format();
    }
}