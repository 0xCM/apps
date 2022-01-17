//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using Z0.Asm;

    [Free]
    public interface IAsmMaskOp : IAsmOp
    {
        RegIndexCode RegIndex {get;}

        AsmRegMaskKind MaskKind {get;}

        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.RegMask;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W64;
    }

    [Free]
    public interface IAsmMaskOp<T> : IAsmMaskOp
        where T : unmanaged
    {

    }
}