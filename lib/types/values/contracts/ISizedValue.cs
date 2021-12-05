//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedValue : ITyped
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}

        bool ITerm.IsEmpty
            => ContentWidth == 0;
    }

    public interface ISizedValue<T> : ISizedValue
        where T : unmanaged
    {
        BitWidth ISizedValue.StorageWidth
            => core.size<T>();
    }
}