//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemOp : IMemOp
    {
        public NativeSize Size {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public MemOp(NativeSize size, AsmAddress address)
        {
            Size = size;
            Address = address;
        }
    }
}