//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmExpr : IEquatable<AsmExpr>
    {
        [MethodImpl(Inline), Op]
        public static AsmExpr parse(string src)
        {
            var body = src.Trim();
            var i = text.index(body, Chars.Space);
            if(i>0)
            {
                var monic = text.left(body,i);
                var operands = text.right(body,i).Trim();
                return new AsmExpr(string.Format("{0} {1}", monic, operands));
            }
            return new AsmExpr(body);
        }

        public TextBlock Content {get;}

        const sbyte DefaultPadding = -46;

        [MethodImpl(Inline)]
        public AsmExpr(TextBlock content)
            => Content = content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public string Format()
            => Content.Format();

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content.View;
        }

        public string FormatPadded(int padding = DefaultPadding)
            => string.Format(RP.pad(padding), Content);

        [MethodImpl(Inline)]
        public bool Equals(AsmExpr src)
            => Content.Equals(src.Content);

        public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is AsmExpr x && Equals(x);

        public AsmExpr Replace(string src, string dst)
            => new AsmExpr(Content.Replace(src,dst));

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsValid
        {
            [MethodImpl(Inline)]
            get => IsNonEmpty && !Content.StartsWith("(bad)");
        }

        public bool IsInvalid
        {
            [MethodImpl(Inline)]
            get => IsEmpty || Content.StartsWith("(bad)");
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmExpr src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(string src)
            => new AsmExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(ReadOnlySpan<char> src)
            => new AsmExpr(new string(src));

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(Span<char> src)
            => new AsmExpr(new string(src));

        public static AsmExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmExpr(TextBlock.Empty);
        }
    }
}