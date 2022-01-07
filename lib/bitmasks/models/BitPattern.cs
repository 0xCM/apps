//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [DataType("bitpattern")]
    public readonly struct BitPattern
    {
        readonly string Content;

        [MethodImpl(Inline)]
        public BitPattern(string src)
        {
            Content = src ?? EmptyString;
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Text.Length;
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitPattern(string src)
            => new BitPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator string(BitPattern src)
            => src.Text;

        public static BitPattern Empty => new BitPattern(EmptyString);
    }
}