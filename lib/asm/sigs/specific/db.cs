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
        public readonly struct db : IRegOpClass<db>, IAsmSigOp<db,SysRegToken>
        {
            public AsmSigOpKind Kind
                => AsmSigOpKind.SysReg;

           public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.DB;

            public SysRegToken Token
                => SysRegToken.db;

            [MethodImpl(Inline)]
            public static implicit operator Reg(db src)
                => new Reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(db src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(db src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}