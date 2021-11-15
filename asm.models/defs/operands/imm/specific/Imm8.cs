//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using W = W8;
    using I = imm8;

    /// <summary>
    /// Defines an 8-bit immediate value
    /// </summary>
    [DataType("imm8")]
    public readonly struct imm8 : IImm<I,byte>
    {
        public byte Content {get;}

        [MethodImpl(Inline)]
        public imm8(byte src)
            => Content = src;

        public ImmBitWidth Width => ImmBitWidth.W8;

        public ImmKind Kind => ImmKind.Imm8;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => FastHash.calc(Content);
        }

        public string Format()
            => HexFormatter.format(Content, W, true);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Content == src.Content ? 0 : Content < src.Content ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Content == src.Content;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address8 ToAddress()
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
        public static implicit operator byte(I src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<byte>(I src)
            => new ImmOp<byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(byte src)
            => new I(src);

        public static W W => default;
    }
}