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
    [DataType("imm64", Kind, Width, Width)]
    public readonly struct imm64 : IImm<imm64,ulong>
    {
        public const ImmKind Kind = ImmKind.Imm64;

        public const byte Width = 64;

        public ulong Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm64(ulong src)
            => Value = src;

        public ImmKind ImmKind
            => Kind;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }


        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => HexFormatter.format(Value, W, true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address64 ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator ==(I a, I b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(I a, I b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<ulong>(I src)
            => new ImmOp<ulong>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(ulong src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator I(MemoryAddress src)
            => new I(src);
    }
}