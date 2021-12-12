//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using W = W32;
    using I = imm32;

    /// <summary>
    /// Defines a 32-bit immediate value
    /// </summary>
    [DataType("imm32", Kind, Width, Width)]
    public readonly struct imm32 : IImm<I,uint>
    {
        public const ImmKind Kind = ImmKind.Imm32;

        public const byte Width = 32;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public imm32(uint src)
            => Value = src;

        public ImmBitWidth ImmWidth
            => ImmBitWidth.W32;

        public ImmKind ImmKind
            => ImmKind.Imm32;

        public string Format()
            => HexFormatter.format(Value, W, true);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address32 ToAddress()
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
        public static implicit operator uint(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<uint>(I src)
            => new ImmOp<uint>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(uint src)
            => new I(src);
        public static W W => default;
    }
}