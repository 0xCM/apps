//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CmdLinePart : ITextual
    {
        public readonly string Content;

        [MethodImpl(Inline)]
        public CmdLinePart(string content)
            => Content = content;

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => chars(Content);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Content);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdLinePart(string src)
            => new CmdLinePart(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdLinePart src)
            => src.Content;
    }
}