//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Covers an A-parametric sequence of asci sequences
    /// </summary>
    public readonly struct AsciSeq<S,N> : IAsciSeq<AsciSeq<S,N>,N>
        where S : unmanaged, IAsciSeq<S>
        where N : unmanaged, ITypeNat
    {
        public readonly S Content;

        [MethodImpl(Inline)]
        public AsciSeq(S src)
            => Content = src;

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciCode>(bytes(Content));
        }

        public Span<AsciSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciSymbol>(bytes(Content));
        }

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => SQ.whitespace(Codes);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => SQ.@null(Codes);
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.Hash;
        }

        public int CompareTo(AsciSeq<S,N> src)
            => Content.CompareTo(src.Content);

        public override int GetHashCode()
            => Hash;

        public bool Equals(AsciSeq<S,N> src)
            => Content.Equals(src.Content);
        [MethodImpl(Inline)]
        public static implicit operator S(AsciSeq<S,N> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator AsciSeq<S,N>(S src)
            => new AsciSeq<S,N>(src);
    }
}