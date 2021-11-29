//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public unsafe readonly struct Label : IEquatable<Label>, ITextual
    {
        readonly ulong Storage;

        [MethodImpl(Inline)]
        public Label(MemoryAddress @base, byte length)
        {
            Storage = (ulong)@base | ((ulong)length << 56);
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get => (byte)(Storage >> 56);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => (MemoryAddress)(Storage & 0x00FFFFFF_FFFFFFFFul);
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => core.cover(Address.Pointer<char>(), Length);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Data);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage != 0;
        }

        public bool Equals(Label src)
            => Storage == src.Storage;

        public string Format()
            => new string(Data);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is Label l && Equals(l);

        public static Label Empty => default;

        [MethodImpl(Inline), Op]
        public static implicit operator Label(string src)
            => strings.label(src);

        public static bool operator==(Label a, Label b)
            => a.Equals(b);

        public static bool operator!=(Label a, Label b)
            => !a.Equals(b);
    }
}