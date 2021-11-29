//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IAddress : ITextual, INullity
    {

    }

    public interface IAddress<T> : IAddress
        where T : unmanaged
    {
        T Location {get;}

        bool INullity.IsEmpty
            => Location.Equals(default(T));
    }

    public interface IAddress<F,T> : IAddress<T>, INullary<F>, IEquatable<F>, IComparable<F>
        where F : unmanaged, IAddress<F,T>
        where T : unmanaged
    {

    }
}