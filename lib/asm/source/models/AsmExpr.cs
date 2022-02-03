//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using SP = SymbolicParse;

    [DataType("asm.expr")]
    public readonly struct AsmExpr : IEquatable<AsmExpr>, IComparable<AsmExpr>
    {
        [Op]
        public static AsmExpr define(AsmMnemonic monic, ReadOnlySpan<char> operands)
            => new AsmExpr(string.Format("{0} {1}", monic.Format(MnemonicCase.Lowercase), text.format(operands)));

        [MethodImpl(Inline), Op]
        public static AsmExpr parse(string src)
        {
            var body = src.Trim();
            var i = text.index(body, Chars.Space);
            if(i>0)
            {
                var monic = text.left(body,i);
                return new AsmExpr(string.Format("{0} {1}", monic, text.right(body,i).Trim()));
            }
            return new AsmExpr(body);
        }

        public static Outcome parse(in AsciLine src, out AsmBlockLabel label, out AsmExpr expr)
        {
            label = AsmBlockLabel.Empty;
            expr = AsmExpr.Empty;
            var content = src.Codes;
            var i = SQ.index(content, AsciCode.Colon);
            if(i < 0)
                return false;

            label = new AsmBlockLabel(text.format(SQ.left(content, i)).Trim());
            expr = text.format(SQ.right(content, i)).Replace(Chars.Tab,Chars.Space).Trim();

            return true;
        }

        public static Outcome parse(ReadOnlySpan<AsciCode> src, out AsmExpr dst)
        {
            dst = AsmExpr.Empty;
            var outcome = Outcome.Success;
            var i = SP.SkipWhitespace(src);
            if(i == NotFound)
                return (false,"Input was empty");

            var remainder = slice(src,i);
            i = SQ.index(remainder, AsciCode.Space);
            if(i == NotFound)
            {
                var monic = new AsmMnemonic(text.format(remainder).Trim());
                var operands = Span<char>.Empty;
                dst = define(monic, operands);
            }
            else
            {
                var monic = new AsmMnemonic(text.format(slice(remainder,0, i)).Trim());
                var operands = text.format(slice(remainder,i)).Trim();
                dst = define(monic, operands);
            }

            return outcome;
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
            => asm.cell(src.Format(), AsmPartKind.Expr);

        public static AsmExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmExpr(TextBlock.Empty);
        }
    }
}