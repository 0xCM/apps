//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedType : ITyped
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}

        bool ITerm.IsEmpty
            => ContentWidth == 0;
    }

    public interface ISizedType<T> : ISizedType
        where T : unmanaged
    {
        BitWidth ISizedType.StorageWidth
            => core.size<T>();
    }
}