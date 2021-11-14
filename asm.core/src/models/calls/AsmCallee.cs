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
    /// Represents the target of an invocation
    /// </summary>
    public struct AsmCallee
    {
        /// <summary>
        /// The target's base address
        /// </summary>
        public MemoryAddress Base {get;}

        /// <summary>
        /// The target's identifier
        /// </summary>
        public string Identity {get;}

        [MethodImpl(Inline)]
        public AsmCallee(MemoryAddress @base, string identity)
        {
            Identity = identity;
            Base = @base;
        }
    }
}