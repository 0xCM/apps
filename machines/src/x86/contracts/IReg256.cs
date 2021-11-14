//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    public interface IReg256<T> : IReg<W256,T>
        where T : unmanaged
    {

    }

    public interface IReg256<H,T> : IReg256<T>
        where H : struct, IReg256<H,T>
        where T : unmanaged
    {

    }
}