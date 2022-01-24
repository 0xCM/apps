//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;


    partial class AsmSigModels
    {
        public readonly struct cr : IRegOpClass<cr>, IAsmSigOp<cr,SysRegToken>
        {
            public AsmSigOpKind OpKind
                => AsmSigOpKind.SysReg;
            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.CR;

            public SysRegToken Token
                => SysRegToken.cr;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(cr src)
                => asm.sigop(src.OpKind, src.Token);
        }
    }
}