//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedType : ITypeDef
    {
        BitWidth StorageWidth {get;}

        BitWidth ContentWidth {get;}

        bool ITypeDef.IsSized
            => true;
    }

    public interface ISizedType<T> : ISizedType
        where T : ISizedType<T>, new()
    {

    }
}