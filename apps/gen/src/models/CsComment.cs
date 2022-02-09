//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CsComment : ITextual
    {
        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public CsComment(string content)
        {
            Content = content;
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

        public void Render(uint indent, ITextBuffer dst)
        {
            dst.IndentLine(indent,"/// <summary>");
            dst.IndentLineFormat(indent,"/// {0}", text.ifempty(Content, "Undocumented"));
            dst.IndentLine(indent,"/// </summary>");
        }

        public string Format(uint indent)
        {
            var dst = text.buffer();
            Render(indent,dst);
            return dst.Emit();
        }

        public string Format()
            => Format(0);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CsComment(string content)
            => new CsComment(content);

        public static CsComment Empty
            => new CsComment(EmptyString);
    }
}