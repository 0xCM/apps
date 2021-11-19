//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    public interface IReg64<T> : IReg<W64,T>
        where T : unmanaged
    {

    }

    public interface IReg64<H,T> : IReg64<T>
        where H : struct, IReg64<H,T>
        where T : unmanaged
    {

    }
}