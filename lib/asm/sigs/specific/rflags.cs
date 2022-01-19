//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        public readonly struct rflags : IRegOpClass<rflags>
        {
            public AsmOpClass OpClass => AsmOpClass.Reg;

            public NativeSize Size => NativeSizeCode.W64;

            public RegClassCode RegClass => RegClassCode.FLAG;

            [MethodImpl(Inline)]
            public static implicit operator reg(rflags src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(rflags src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}