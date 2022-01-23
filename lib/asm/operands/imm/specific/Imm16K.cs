//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;
    using static core;

    using W = W16;

    /// <summary>
    /// Defines a refined 16-bit immediate value
    /// </summary>
    [DataType("imm16<k:{0}>", Kind, Width, Width)]
    public readonly struct imm16<K> : IImm<imm16<K>, K>
        where K : unmanaged
    {
        public const ImmKind Kind = ImmKind.Imm16;

        public const byte Width = 16;

        public K Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm16(K value)
            => Value = value;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;

        public ImmKind ImmKind
            => Kind;

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
        public ushort AsPrimitive()
            => bw16(this);

        [MethodImpl(Inline)]
        public static implicit operator K(imm16<K> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator imm16<K>(K src)
            => new imm16<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(imm16<K> src)
            => src.AsPrimitive();

        [MethodImpl(Inline)]
        public static implicit operator Imm(imm16<K> src)
            => new Imm(src.ImmKind, src.AsPrimitive());
    }
}