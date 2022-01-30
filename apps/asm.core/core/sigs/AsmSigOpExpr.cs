//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Represents an operand in the context of an instruction signature
    /// </summary>
    [DataType("asm.sigop.expr")]
    public readonly struct AsmSigOpExpr : IEquatable<AsmSigOpExpr>
    {
        readonly string Content;

        [MethodImpl(Inline)]
        internal AsmSigOpExpr(string data)
        {
            Content = data.Trim();
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Text;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.length(Text) == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.length(Text) != 0;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.marvin(Text);
        }

        public bool IsModified
            => Text.Contains(Chars.LBrace);

        public Outcome Modified(out string target, out AsmOpModifierKind mod)
        {
            mod = AsmOpModifierKind.None;
            target = EmptyString;
            var i = text.index(Text, Chars.LBrace);
            if(i > 0)
            {
                target = text.trim(text.left(Text,i));
                var modtext = text.trim(text.right(Text,i-1));
                switch(modtext)
                {
                    case "{k1}{z}":
                        mod = AsmOpModifierKind.k1z;
                    break;
                    case "{k1}":
                        mod = AsmOpModifierKind.k1;
                    break;
                    case "{z}":
                        mod = AsmOpModifierKind.z;
                    break;
                    case "{k2}":
                        mod = AsmOpModifierKind.k2;
                    break;
                    case "{sae}":
                        mod = AsmOpModifierKind.sae;
                    break;
                    case "{er}":
                        mod = AsmOpModifierKind.er;
                    break;
                    default:
                    break;
                }
            }
            return mod != 0;
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public bool Equals(AsmSigOpExpr src)
            => Text.Equals(src.Text);

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is AsmSigOpExpr x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOpExpr(string src)
            => new AsmSigOpExpr(src);

        public static AsmSigOpExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSigOpExpr(EmptyString);
        }
    }
}