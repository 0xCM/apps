//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public unsafe readonly struct SourceText : IEquatable<SourceText>, ITextual
    {
        readonly MemoryAddress Address;

        readonly uint Length;

        [MethodImpl(Inline)]
        public SourceText(MemoryAddress @base, uint length)
        {
            Address = @base;
            Length = length;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => core.cover(Address.Pointer<char>(), Length);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Data);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public bool Equals(SourceText src)
            => text.equals(Data,src.Data);

        public string Format()
            => new string(Data);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is SourceText l && Equals(l);

        public static SourceText Empty => default;

        public static bool operator==(SourceText a, SourceText b)
            => a.Equals(b);

        public static bool operator!=(SourceText a, SourceText b)
            => !a.Equals(b);
    }
}