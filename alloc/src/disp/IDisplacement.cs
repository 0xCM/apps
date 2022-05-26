//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Free]
    public interface IDisplacement : IAsmOp
    {
        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Disp;

        long Value {get;}

        bool Positive => Value > 0;

        bool Negative => Value < 0;
    }

    [Free]
    public interface IDisplacement<T> : IDisplacement
        where T : unmanaged
    {
        new T Value {get;}
    }

    [Free]
    public interface IDisplacement<H,T> : IDisplacement<T>, IEquatable<H>
        where T : unmanaged
        where H : unmanaged, IDisplacement<H,T>
    {

    }
}