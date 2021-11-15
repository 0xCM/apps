//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

   public readonly struct SyntaxFragment<T> : ITextual
        where T : ISyntaxPart<T>
    {
        /// <summary>
        /// The content origin
        /// </summary>
        public GridPoint<uint> Location {get;}

        /// <summary>
        /// The line content
        /// </summary>
        public T Content {get;}

        [MethodImpl(Inline)]
        public SyntaxFragment(GridPoint<uint> location, T content)
        {
            Location = location;
            Content = content;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content.ToString();

        public override string ToString()
            => Format();

        public static implicit operator SyntaxFragment(SyntaxFragment<T> src)
            => new SyntaxFragment(src.Location, src.Format());
    }
}