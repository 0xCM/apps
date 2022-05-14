//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Pairs a symbol with it's hash
    /// </summary>
    public readonly struct SymbolHash
    {
        public readonly StringRef Symbol;

        public readonly Hash32 HashCode;

        [MethodImpl(Inline)]
        internal SymbolHash(StringRef symbol, Hash32 hash)
        {
            Symbol = symbol;
            HashCode = hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsEmpty || HashCode == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsNonEmpty && HashCode != 0;
        }

        public string Format()
            => string.Format("hash({0}) = {1}", Symbol, HashCode);

        public override string ToString()
            => Format();

        public static SymbolHash Empty
        {
            [MethodImpl(Inline)]
            get => new SymbolHash(StringRef.Empty, 0);
        }
    }
}