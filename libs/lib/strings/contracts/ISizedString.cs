//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISizedString : IString
    {
        uint CharCapacity {get;}

        uint Length {get;}

        BitWidth StorageWidth {get;}

        BitWidth CharWidth {get;}

        BitWidth ISized.Width
            => CharWidth*CharCapacity;
    }

    [Free]
    public interface ISizedString<F,T> : ISizedString, IString<F,T>
        where T : unmanaged, IEquatable<T>, IComparable<T>
        where F : unmanaged, ISizedString<F,T>
    {

    }
}