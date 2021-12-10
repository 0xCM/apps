//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISizedString : ISized, ITextual, INullity
    {
        uint CharCapacity {get;}

        uint Length {get;}

        BitWidth StorageWidth {get;}

        BitWidth CharWidth {get;}

        BitWidth ISized.Width
            => CharWidth*CharCapacity;
    }


    [Free]
    public interface ISizedString<T> : ISizedString, IComparable<T>, IEquatable<T>
        where T : struct, ISizedString<T>
    {

    }
}