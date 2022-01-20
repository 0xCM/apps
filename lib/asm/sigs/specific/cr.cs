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
            public AsmSigOpKind Kind
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
            public static implicit operator reg(cr src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(cr src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(cr src)
                => asm.sigop(src.Kind, src.Token);


        }
    }
}