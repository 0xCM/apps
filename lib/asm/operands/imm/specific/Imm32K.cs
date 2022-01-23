//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using W = W32;

    /// <summary>
    /// Defines a refined 32-bit immediate value
    /// </summary>
    [DataType("imm32<k:{0}>", Kind, Width, Width)]
    public readonly struct imm32<K> : IImm<imm32<K>, K>
        where K : unmanaged
    {
        public const ImmKind Kind = ImmKind.Imm32;

        public const byte Width = 32;

        public K Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm32(K src)
            => Value = src;

        public ImmKind ImmKind
            => Kind;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;

        [MethodImpl(Inline)]
        public uint AsPrimitive()
            => bw32(this);

        [MethodImpl(Inline)]
        public string Format()
            => HexFormatter.format(Value, W, true);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Value);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator K(imm32<K> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator imm32<K>(K src)
            => new imm32<K>(src);

       [MethodImpl(Inline)]
        public static implicit operator Imm(imm32<K> src)
            => new Imm(src.ImmKind, src.AsPrimitive());

    }
}