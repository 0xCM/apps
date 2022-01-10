//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDisplacement : IAsmOp
    {
        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Disp;

        long Value {get;}

    }

    [Free]
    public interface IDisplacement<T> : IDisplacement
        where T : unmanaged
    {
        new T Value {get;}
    }

    [Free]
    public interface IDisplacement<H,T> : IDisplacement<T>
        where T : unmanaged
        where H : unmanaged, IDisplacement<H,T>
    {

    }
}