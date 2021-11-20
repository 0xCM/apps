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
    [DataType("imm64{k}")]
    public readonly struct imm64<K> : IImm<imm64<K>,K>
        where K : unmanaged
    {
        public K Content {get;}

        public ImmBitWidth Width => ImmBitWidth.W64;

        public ImmKind Kind => ImmKind.Imm64;

        [MethodImpl(Inline)]
        public imm64(K src)
            => Content = src;

        [MethodImpl(Inline)]
        public ulong AsPrimitive()
            => bw64(this);

        public string Format()
            => HexFormatter.format(Content, W, true);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Content);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator K(imm64<K> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator imm64<K>(K src)
            => new imm64<K>(src);

        public static W W => default;
    }
}