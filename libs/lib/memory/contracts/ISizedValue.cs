//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedValue : IValued
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}

        bool INullity.IsEmpty
            => ContentWidth == 0;
    }

    public interface ISizedValue<T> : ISizedValue, IValued<T>
        where T : unmanaged
    {
        BitWidth ISizedValue.StorageWidth
            => core.size<T>();
    }
}