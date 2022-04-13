//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using N = N64;
    using W = W512;
    using A = asci64;
    using S = Vector512<byte>;
    using api = Asci;

    [DataWidth(512)]
    public readonly struct asci64 : IAsciSeq<A,N>
    {
        public const int Size = 64;

        internal readonly S Storage;

        [MethodImpl(Inline)]
        public asci64(S src)
            => Storage = src;

        [MethodImpl(Inline)]
        public asci64(string src)
            => Storage = api.encode(n,src).Storage;

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
            get => api.length(this);
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => api.bytes(this);
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
            get => api.decode(this);
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => text.format(Decoded,true);
        }

        [MethodImpl(Inline)]
        public void CopyTo(Span<byte> dst)
            => api.copy(this,dst);

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Text.CompareTo(src.Text);

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Storage.Equals(src.Storage);

         public override int GetHashCode()
            => Storage.GetHashCode();

        public override bool Equals(object src)
            => src is A j && Equals(j);


        public static A Spaced
        {
            [MethodImpl(Inline)]
            get => api.init(n);
        }

        public static A Null => default;

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