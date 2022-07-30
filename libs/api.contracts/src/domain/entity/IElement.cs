//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IElement
    {


    }

    [Free]
    public interface IElement<T> : IElement, IEquatable<T>, IComparable<T>
        where T : IElement<T>
    {

    }

}