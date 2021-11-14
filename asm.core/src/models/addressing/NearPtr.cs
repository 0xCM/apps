//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NearPtr
    {
        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public NearPtr(MemoryAddress address)
        {
            Address = address;
        }

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NearPtr(MemoryAddress src)
            => new NearPtr(src);
    }
}