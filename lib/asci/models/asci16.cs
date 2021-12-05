//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    using N = N16;
    using W = W128;
    using A = asci16;
    using S = System.Runtime.Intrinsics.Vector128<byte>;

    /// <summary>
    /// Defines an asci code sequence of length 16
    /// </summary>
    public readonly struct asci16 : IAsciSeq<A,N>
    {
        public const int Size = 16;

        public readonly S Storage;

        [MethodImpl(Inline)]
        public asci16(S src)
            => Storage = src;

        [MethodImpl(Inline)]
        public asci16(string src)
            => Storage = Asci.encode(n,src).Storage;

        [MethodImpl(Inline)]
        public asci16(ReadOnlySpan<byte> src)
            => Storage = cpu.vload(w, first(src));

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => IsNull || Equals(Spaced);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => Equals(Null);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Equals(Null);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Equals(Null);
        }

        public A Zero
        {
            [MethodImpl(Inline)]
            get => Null;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Asci.length(this);
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Asci.bytes(this);
        }

        public AsciCode this[int index]
        {
            [MethodImpl(Inline)]
            get => (AsciCode)Storage.GetElement(index);
        }

        public asci2 this[byte index, N2 size]
        {
            [MethodImpl(Inline)]
            get =>  Storage.As<byte,ushort>().GetElement(index/2);
        }

        public asci4 this[byte index, N4 size]
        {
            [MethodImpl(Inline)]
            get =>  Storage.As<byte,uint>().GetElement(index/4);
        }

        public asci8 this[byte index, N8 size]
        {
            [MethodImpl(Inline)]
            get =>  Storage.As<byte,ulong>().GetElement(index/8);
        }

        public ReadOnlySpan<char> Decoded
        {
            [MethodImpl(Inline)]
            get => Asci.decode(this);
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Asci.format(this);
        }

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Storage.Equals(src.Storage);

        [MethodImpl(Inline)]
        public void CopyTo(Span<byte> dst)
            => Asci.copy(this,dst);

        [MethodImpl(Inline)]
        public void CopyTo(ref byte dst)
            => Asci.copy(this, ref dst);

         public override int GetHashCode()
            => Storage.GetHashCode();

        public override bool Equals(object src)
            => src is A j && Equals(j);

        [MethodImpl(Inline)]
        public string Format()
            => Text.Trim();

        public override string ToString()
            => Format();

        public static A Spaced
        {
            [MethodImpl(Inline)]
            get => Asci.init(n);
        }

        public static A Null
        {
            [MethodImpl(Inline)]
            get => new A(default(S));
        }

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Text.CompareTo(src.Text);

        [MethodImpl(Inline)]
        public static implicit operator A(string src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(TextBlock src)
            => new A(src.Format());

        [MethodImpl(Inline)]
        public static implicit operator string(A src)
            => src.Text;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(A src)
            => src.View;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(A src)
            => src.Decoded;

        [MethodImpl(Inline)]
        public static bool operator ==(A a, A b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(A a, A b)
            => !a.Equals(b);

        static N n => default;

        static W w => default;
    }
}