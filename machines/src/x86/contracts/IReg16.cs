//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    public interface IReg16<T> : IReg<W16,T>
        where T : unmanaged
    {

    }

    public interface IReg16<H,T> : IReg16<T>
        where H : struct, IReg16<H,T>
        where T : unmanaged
    {

    }
}