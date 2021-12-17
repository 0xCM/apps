//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IScalarType : ISizedType
    {
        ScalarClass ScalarClass {get;}

        ulong IType.Kind
            => 0;
    }

    public interface IScalarType<K> : IType<K>, IScalarType
        where K : unmanaged
    {
        ulong IType.Kind
            => core.bw64(Kind);
    }
}