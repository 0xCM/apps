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
    /// Captures a method entry point
    /// </summary>
    public readonly struct MethodEntryPoint<K>
        where K : unmanaged
    {
        public CliToken Id {get;}

        public MemoryAddress Location {get;}

        public K Kind {get;}

        [MethodImpl(Inline)]
        public MethodEntryPoint(CliToken id, MemoryAddress address, K kind)
        {
            Id = id;
            Location = address;
            Kind = kind;
        }
    }
}