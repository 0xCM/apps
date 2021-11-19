//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    public interface IYmmReg : IReg<W256,Cell256>
    {

    }

    /// <summary>
    /// Characterizes a 128-bit vectorized register reification of parametric index
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="N">The index type</typeparam>
    public interface IYmmReg<F,R> : IYmmReg, IReg<W256,Cell256>
        where F : struct, IYmmReg<F,R>
        where R : unmanaged
    {

    }
}