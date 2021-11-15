//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents an expression that identifies an instruction
    /// </summary>
    public readonly struct AsmSigInfo : ITextExpr<AsmSigInfo>, IComparable<AsmSigInfo>
    {
        public AsmMnemonic Mnemonic {get;}

        public TextBlock Content {get;}

        public AsmSigInfo(AsmMnemonic mnemonic, TextBlock content)
        {
            Mnemonic = mnemonic;
            Content = content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
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


        public override int GetHashCode()
            => Content.GetHashCode();

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmSigInfo src)
            => Content.Equals(src.Content);

        public override bool Equals(object src)
            => src is AsmSigInfo x && Equals(x);

        public int CompareTo(AsmSigInfo src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator TextBlock(AsmSigInfo src)
            => new TextBlock(src.Content);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmSigInfo a, AsmSigInfo b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmSigInfo a, AsmSigInfo b)
            => !a.Equals(b);

        public static AsmSigInfo Empty
            => new AsmSigInfo(AsmMnemonic.Empty, TextBlock.Empty);
    }
}