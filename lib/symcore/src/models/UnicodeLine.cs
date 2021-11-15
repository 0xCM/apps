//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct UnicodeLine : IComparable<UnicodeLine>
    {
        public LineNumber LineNumber {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public UnicodeLine(uint number, uint start, string src)
        {
            LineNumber = number;
            Content = src;
        }

        [MethodImpl(Inline)]
        public UnicodeLine(uint number, string src)
        {
            LineNumber = number;
            Content = src;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public int RenderLength
        {
            [MethodImpl(Inline)]
            get => Content.Length + LineNumber.RenderLength;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public string Format()
            => Lines.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(UnicodeLine other)
            => LineNumber.CompareTo(other.LineNumber);

        public static UnicodeLine Empty
        {
            [MethodImpl(Inline)]
            get => new UnicodeLine(0,0,EmptyString);
        }
    }
}