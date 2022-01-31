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
    [DataType("asm.caller")]
    public readonly struct AsmCaller
    {
        [MethodImpl(Inline), Op]
        public static AsmCaller define(MemoryAddress @base, string symbol)
            => new AsmCaller(@base, symbol);

        public MemoryAddress Base {get;}

        public string Identity {get;}

        [MethodImpl(Inline)]
        public AsmCaller(MemoryAddress address, string identity)
        {
            Base = address;
            Identity = identity;
        }

        public string Format()
            => string.Format("{0} {1}", Base, Identity);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCaller((MemoryAddress address, string name) src)
            => new AsmCaller(src.address, src.name);
    }
}