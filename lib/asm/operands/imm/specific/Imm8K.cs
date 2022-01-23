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

    using W = W8;

    /// <summary>
    /// Defines a refined 8-bit immediate value
    /// </summary>
    [DataType("imm8<k:{0}>", Kind, Width, Width)]
    public readonly struct imm8<K> : IImm<imm8<K>,K>
        where K : unmanaged
    {
        public const ImmKind Kind = ImmKind.Imm8;

        public const byte Width = 8;

        public K Value {get;}

        [MethodImpl(Inline)]
        public imm8(K src)
            => Value = src;

        public ImmKind ImmKind
            => Kind;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;

        [MethodImpl(Inline)]
        public string Format()
            => HexFormatter.format(Value, W, true);

        [MethodImpl(Inline)]
        public byte AsPrimitive()
            => bw8(this);

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
        public static implicit operator K(imm8<K> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(imm8<K> src)
            => src.AsPrimitive();

        [MethodImpl(Inline)]
        public static implicit operator imm8<K>(K src)
            => new imm8<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(imm8<K> src)
            => new Imm(src.ImmKind, src.AsPrimitive());

        public static W W => default;
    }
}