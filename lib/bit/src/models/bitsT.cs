//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a bit sequence representation compatible with both llvm and SMTLib 'FixedSizeBitVectors' theory
    /// </summary>
    public struct bits<T>
        where T : unmanaged
    {
        public const string Identifier = "bits<{0}>";

        public T Packed;

        public uint N;

        public string TypeName
            => string.Format(Identifier, N);

        [MethodImpl(Inline)]
        public bits(uint n, T src)
        {
            N = n;
            Packed = src;
        }

        public bit this[uint index]
        {
            [MethodImpl(Inline)]
            get => bit.element(this,index);
        }

        public string Format()
            => bit.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator bits<T>((uint n, T value) src)
            => new bits<T>(src.n, src.value);
    }
}