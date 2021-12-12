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

    using W = W64;

    /// <summary>
    /// Defines a refined 64-bit immediate value
    /// </summary>
    [DataType("imm64<k:{0}>", Kind, Width, Width)]
    public readonly struct imm64<K> : IImm<imm64<K>,K>
        where K : unmanaged
    {
        public const ImmKind Kind = ImmKind.Imm16;

        public const byte Width = 64;
        public K Value {get;}

        [MethodImpl(Inline)]
        public imm64(K src)
            => Value = src;

        [MethodImpl(Inline)]
        public ulong AsPrimitive()
            => bw64(this);

        public ImmKind ImmKind
            => Kind;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;
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
        public static implicit operator K(imm64<K> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator imm64<K>(K src)
            => new imm64<K>(src);

        public static W W => default;
    }
}