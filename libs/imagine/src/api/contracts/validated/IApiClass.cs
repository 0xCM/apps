//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Refs;

    public interface IApiClass<K> : IApiClass
        where K : unmanaged
    {
        K Kind  {get;}

        ApiClassKind IApiClass.ClassId
            => @as<K,ApiClassKind>(Kind);
    }
}