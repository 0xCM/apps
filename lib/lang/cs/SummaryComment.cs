//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CsModels
    {
        /// <summary>
        /// Represents me
        /// </summary>
        public readonly struct SummaryComment : ITextual
        {
            public TextBlock Content {get;}

            [MethodImpl(Inline)]
            public SummaryComment(string content)
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
                var dst = TextTools.buffer();
                Render(indent,dst);
                return dst.Emit();
            }

            public string Format()
                => Format(0);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator SummaryComment(string content)
                => new SummaryComment(content);

            public static SummaryComment Empty
                => new SummaryComment(EmptyString);
        }
    }
}