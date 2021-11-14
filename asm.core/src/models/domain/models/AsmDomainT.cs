//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using api = AsmDomains;

    public struct AsmDomain<T>
        where T : unmanaged
    {
        public static uint CellSize => size<T>();

        public T Bits;

        public readonly uint Limit;

        [MethodImpl(Inline)]
        public AsmDomain(T bits, uint? limit = null)
        {
            Bits = bits;
            Limit = limit ?? core.width<T>();
        }

        public string Format()
            =>  api.format(this);

        public override string ToString()
            => Format();
    }
}