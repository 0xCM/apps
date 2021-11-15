//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MethodSlot
    {
        public MemoryAddress Address {get;}

        public Name Name {get;}

        [MethodImpl(Inline)]
        public MethodSlot(Name name, MemoryAddress address)
        {
            Name = name;
            Address = address;
        }

        public string Format()
            => string.Format("{0}: {1}", Address, Name);

        public override string ToString()
            => Format();
    }
}