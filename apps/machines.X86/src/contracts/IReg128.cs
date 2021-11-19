//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    public interface IReg128<T> : IReg<W128,T>
        where T : unmanaged
    {

    }

    public interface IReg128<H,T> : IReg128<T>
        where H : struct, IReg128<H,T>
        where T : unmanaged
    {

    }
}