//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISequential
    {
        uint Seq {get;}
    }

    [Free]
    public interface ISequential<T> : ISequential
        where T : unmanaged
    {
        new T Seq {get;}

        uint ISequential.Seq
            => core.bw32(Seq);
    }
}