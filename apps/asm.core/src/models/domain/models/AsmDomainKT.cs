//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct AsmDomain<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public static uint CellSize => size<T>();

        public K Kind;

        public T Bits;

        public readonly uint Limit;

        [MethodImpl(Inline)]
        public AsmDomain(K kind, T bits, uint? limit = null)
        {
            Kind = kind;
            Bits = bits;
            Limit = limit ?? core.width<T>();
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmDomain<T>(AsmDomain<K,T> src)
            => new AsmDomain<T>(src.Bits, src.Limit);
    }
}