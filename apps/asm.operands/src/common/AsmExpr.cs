//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [DataType("asm.expr")]
    public readonly struct AsmExpr : IEquatable<AsmExpr>, IComparable<AsmExpr>
    {
        [Op]
        public static AsmExpr define(AsmMnemonic monic, ReadOnlySpan<char> operands)
            => new AsmExpr(string.Format("{0} {1}", monic.Format(MnemonicCase.Lowercase), text.format(operands)));

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

        public AsmInlineComment Comment()
        {
            var result = AsmParser.comment(Data, out var comment);
            if(result)
                return comment;
            else
                return AsmInlineComment.Empty;
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

        public AsmPartKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.Expr;
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

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmExpr src)
            => AsmCell.define(src.Format(), AsmPartKind.Expr);

        public static AsmExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmExpr(TextBlock.Empty);
        }
    }
}