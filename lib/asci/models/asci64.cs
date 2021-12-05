//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using N = N64;
    using W = W512;
    using A = asci64;
    using S = Vector512<byte>;

    public readonly struct asci64 : IAsciSeq<A,N>
    {
        internal readonly S Storage;

        [MethodImpl(Inline)]
        public asci64(S src)
            => Storage = src;

        [MethodImpl(Inline)]
        public asci64(string src)
            => Storage = Asci.encode(n,src).Storage;

        [MethodImpl(Inline)]
        public asci64(ReadOnlySpan<byte> src)
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
            get => Storage.Equals(default);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Storage.Equals(default);
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

        public A Zero
        {
            [MethodImpl(Inline)]
            get => default;
        }

        public asci32 Lo
        {
            [MethodImpl(Inline)]
            get => new asci32(Storage.Lo);
        }

        public asci32 Hi
        {
            [MethodImpl(Inline)]
            get => new asci32(Storage.Hi);
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
        public int CompareTo(A src)
            => Text.CompareTo(src.Text);

        [MethodImpl(Inline)]
        public string Format()
            => Text.Trim();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Storage.Equals(src.Storage);

         public override int GetHashCode()
            => Storage.GetHashCode();

        public override bool Equals(object src)
            => src is A j && Equals(j);

        public const int Size = 64;

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

        static N n => default;

        static W w => default;
    }
}