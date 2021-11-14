//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmCallSite
    {
        public AsmCaller Caller {get;}

        public Address16 LocalOffset {get;}

        public uint4 InstructionSize {get;}

        [MethodImpl(Inline)]
        public AsmCallSite(AsmCaller caller, Address16 offset, uint4 size)
        {
            Caller = caller;
            LocalOffset = offset;
            InstructionSize = size;
        }

        public string Format()
            => string.Format("{0}:{1}", Caller, LocalOffset);

        public override string ToString()
            => Format();

    }
}