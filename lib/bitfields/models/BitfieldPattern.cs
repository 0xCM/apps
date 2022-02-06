//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [DataType("bitfields.pattern")]
    public readonly struct BitfieldPattern
    {
        readonly string Content;

        [MethodImpl(Inline)]
        public BitfieldPattern(string src)
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
        public static implicit operator BitfieldPattern(string src)
            => new BitfieldPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator string(BitfieldPattern src)
            => src.Text;

        public static BitfieldPattern Empty => new BitfieldPattern(EmptyString);
    }
}