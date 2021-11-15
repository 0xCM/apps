//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using Z0.Asm;

    [Free]
    public interface IImmOp : IAsmOp, ITextual
    {
        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Imm;
    }

    [Free]
    public interface IImmOp<T> : IImmOp, IContented<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IImm : IImmOp
    {

    }

    [Free]
    public interface IImm<T> : IImm, IImmOp<T>, IDataType<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IImm<F,T> : IImm<T>
        where F : unmanaged, IImm<F,T>
        where T : unmanaged
    {
        NativeSize IAsmOp.Size
            => Sizes.native(core.width<T>());
    }
}