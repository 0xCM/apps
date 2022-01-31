//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("asm.callsite")]
    public readonly struct AsmCallSite
    {
        [MethodImpl(Inline), Op]
        public static AsmCallSite define(LocatedSymbol caller, Address16 offset, uint4 size)
            => new AsmCallSite(caller, offset, size);

        public LocatedSymbol Caller {get;}

        public Address16 LocalOffset {get;}

        public uint4 InstructionSize {get;}

        [MethodImpl(Inline)]
        public AsmCallSite(LocatedSymbol caller, Address16 offset, uint4 size)
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