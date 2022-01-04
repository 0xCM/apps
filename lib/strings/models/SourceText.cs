//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public unsafe readonly struct SourceText : IMemoryString<SourceText>
    {
        public MemoryAddress Address {get;}

        public int Length {get;}

        [MethodImpl(Inline)]
        public SourceText(MemoryAddress @base, int length)
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

        public int CompareTo(SourceText src)
            => Data.CompareTo(src.Data, StringComparison.InvariantCulture);
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