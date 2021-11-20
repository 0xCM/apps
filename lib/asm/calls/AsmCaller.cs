//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a based code block that issues a call instruction
    /// </summary>
    public readonly struct AsmCaller
    {
        public MemoryAddress Base {get;}

        public string Identity {get;}

        [MethodImpl(Inline)]
        public AsmCaller(MemoryAddress address, string identity)
        {
            Base = address;
            Identity = identity;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmCaller((MemoryAddress address, string name) src)
            => new AsmCaller(src.address, src.name);
    }
}