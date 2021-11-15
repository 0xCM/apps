//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using W = W16;
    using I = imm16;

    /// <summary>
    /// Defines a 16-bit immediate value
    /// </summary>
    [DataType("imm16")]
    public readonly struct imm16 : IImm<I,ushort>
    {
        public ushort Content {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm16(ushort src)
            => Content = src;

        public ImmBitWidth Width
            => ImmBitWidth.W16;

        public ImmKind Kind
            => ImmKind.Imm16;

        public string Format()
            => HexFormatter.format(Content, W, true);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => FastHash.calc(Content);
        }

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
        public Address16 ToAddress()
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
        public static implicit operator ushort(I src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<ushort>(imm16 src)
            => new ImmOp<ushort>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(ushort src)
            => new I(src);
     }
}