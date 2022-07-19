//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IElement<T> : IEquatable<T>, IComparable<T>
        where T : IElement<T>
    {

    }

}