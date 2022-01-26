//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using Z0.Asm;

    [Free]
    public interface IRegMask : IAsmOp
    {
        RegOp Target {get;}

        RegIndex Mask {get;}

        RegMaskKind Kind {get;}

        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.RegMask;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W64;
    }

    [Free]
    public interface IRegMask<T> : IRegMask
        where T : unmanaged
    {

    }
}