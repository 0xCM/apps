//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        public readonly struct db : IRegOpClass<db>
        {
           public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.DB;

            [MethodImpl(Inline)]
            public static implicit operator reg(db src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(db src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}