//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataType
    {
        asci64 Name {get;}

        DataSize Size {get;}

        Hash32 Hash
            => GetHashCode();
    }

    [Free]
    public interface IDataType<T> : IDataType, IEquatable<T>
        where T : IDataType<T>
    {

    }
}