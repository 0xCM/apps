//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using W = W64;
    using I = imm64;

    /// <summary>
    /// Defines a 64-bit immediate value
    /// </summary>
    [DataType("imm64")]
    public readonly struct imm64 : IImm<imm64,ulong>
    {
        public ulong Content {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm64(ulong src)
            => Content = src;

        public ImmBitWidth Width => ImmBitWidth.W64;

        public ImmKind Kind => ImmKind.Imm64;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => FastHash.calc(Content);
        }


        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => HexFormatter.format(Content, W, true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Content == src.Content ? 0 : Content < src.Content ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Content == src.Content;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address64 ToAddress()
            => Content;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Content < b.Content;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Content > b.Content;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Content <= b.Content;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Content >= b.Content;

        [MethodImpl(Inline)]
        public static bool operator ==(I a, I b)
            => a.Content == b.Content;

        [MethodImpl(Inline)]
        public static bool operator !=(I a, I b)
            => a.Content != b.Content;

        [MethodImpl(Inline)]
        public static implicit operator ulong(I src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<ulong>(I src)
            => new ImmOp<ulong>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(ulong src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(I src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator I(MemoryAddress src)
            => new I(src);
    }
}