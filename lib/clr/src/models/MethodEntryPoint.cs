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
    public readonly struct MethodEntryPoint
    {
        public CliToken Id {get;}

        public MemoryAddress Location {get;}

        [MethodImpl(Inline)]
        public MethodEntryPoint(CliToken id, MemoryAddress address)
        {
            Id = id;
            Location = address;
        }

        public string Format()
            => string.Format("{0}: {1}", Id, Location);

        public override string ToString()
            => Format();
    }
}