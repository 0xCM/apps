//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmStatement : ITextual, INullity, IEquatable<AsmStatement>, IComparable<AsmStatement>
    {
        readonly TextBlock Data;

        [MethodImpl(Inline)]
        public AsmStatement(TextBlock src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmStatement src)
            => Data.Equals(src.Data);

        public int CompareTo(AsmStatement src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => (int)Data.Hash;

        public override bool Equals(object src)
            => src is AsmStatement s && Equals(s);

        [MethodImpl(Inline)]
        public static implicit operator AsmStatement(string src)
            => new AsmStatement(src);

        public static AsmStatement Empty
        {
            [MethodImpl(Inline)]
            get => new AsmStatement(EmptyString);
        }
    }
}