//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IType
    {
        ulong Kind {get;}
    }

    public interface IType<K> : IType
        where K : unmanaged
    {
        new K Kind {get;}

        ulong IType.Kind
            => core.bw64(Kind);
    }
}