//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    public interface IReg32<T> : IReg<W32,T>
        where T : unmanaged
    {

    }

    public interface IReg32<H,T> : IReg32<T>
        where H : struct, IReg32<H,T>
        where T : unmanaged
    {

    }
}